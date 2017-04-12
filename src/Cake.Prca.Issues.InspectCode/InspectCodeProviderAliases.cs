﻿namespace Cake.Prca.Issues.InspectCode
{
    using Core;
    using Core.Annotations;
    using Core.IO;

    /// <summary>
    /// Contains functionality related to importing code analysis issues from JetBrains Inspect Code
    /// to write them to pull requests.
    /// </summary>
    [CakeAliasCategory(CakeAliasConstants.MainCakeAliasCategory)]
    [CakeNamespaceImport("Cake.Prca.Issues.InspectCode")]
    public static class InspectCodeProviderAliases
    {
        /// <summary>
        /// Gets an instance of a provider for code analysis issues reported by JetBrains Inspect Code using a log file from disk.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logFilePath">Path to the the InspectCode log file.</param>
        /// <returns>Instance of a provider for code analysis issues reported by JetBrains Insepct Code.</returns>
        /// <example>
        /// <para>Report code analysis issues reported by JetBrains Inspect Code to a TFS pull request:</para>
        /// <code>
        /// <![CDATA[
        ///     var repoRoot = new DirectoryPath("c:\repo");
        ///     ReportCodeAnalysisIssuesToPullRequest(
        ///         InspectCodeFromFilePath(
        ///             new FilePath("C:\build\InspectCode.log")),
        ///         TfsPullRequests(
        ///             new Uri("http://myserver:8080/tfs/defaultcollection/myproject/_git/myrepository"),
        ///             "refs/heads/feature/myfeature",
        ///             TfsAuthenticationNtlm()),
        ///         repoRoot);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory(CakeAliasConstants.CodeAnalysisProviderCakeAliasCategory)]
        public static ICodeAnalysisProvider InspectCodeFromFilePath(
            this ICakeContext context,
            FilePath logFilePath)
        {
            context.NotNull(nameof(context));
            logFilePath.NotNull(nameof(logFilePath));

            return context.InspectCode(InspectCodeSettings.FromFilePath(logFilePath));
        }

        /// <summary>
        /// Gets an instance of a provider for code analysis issues reported by JetBrains Inspect Code using log file content.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logFileContent">Content of the the Inspect Code log file.</param>
        /// <returns>Instance of a provider for code analysis issues reported by JetBrains Inspect Code.</returns>
        /// <example>
        /// <para>Report code analysis issues reported by JetBrains Inspect Code to a TFS pull request:</para>
        /// <code>
        /// <![CDATA[
        ///     var repoRoot = new DirectoryPath("c:\repo");
        ///     ReportCodeAnalysisIssuesToPullRequest(
        ///         InspectCodeFromContent(
        ///             logFileContent),
        ///         TfsPullRequests(
        ///             new Uri("http://myserver:8080/tfs/defaultcollection/myproject/_git/myrepository"),
        ///             "refs/heads/feature/myfeature",
        ///             TfsAuthenticationNtlm()),
        ///         repoRoot);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory(CakeAliasConstants.CodeAnalysisProviderCakeAliasCategory)]
        public static ICodeAnalysisProvider InspectCodeFromContent(
            this ICakeContext context,
            string logFileContent)
        {
            context.NotNull(nameof(context));
            logFileContent.NotNullOrWhiteSpace(nameof(logFileContent));

            return context.InspectCode(InspectCodeSettings.FromContent(logFileContent));
        }

        /// <summary>
        /// Gets an instance of a provider for code analysis issues reported by JetBrains Inspect Code using specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">Settings for reading the Inspect Code log.</param>
        /// <returns>Instance of a provider for code analysis issues reported by JetBrains Inspect Code.</returns>
        /// <example>
        /// <para>Report code analysis issues reported by JetBrains Inspect Code to a TFS pull request:</para>
        /// <code>
        /// <![CDATA[
        ///     var repoRoot = new DirectoryPath("c:\repo");
        ///     var settings =
        ///         new InspectCodeSettings(
        ///             new FilePath("C:\build\InspectCode.log"));
        ///
        ///     ReportCodeAnalysisIssuesToPullRequest(
        ///         InspectCode(settings),
        ///         TfsPullRequests(
        ///             new Uri("http://myserver:8080/tfs/defaultcollection/myproject/_git/myrepository"),
        ///             "refs/heads/feature/myfeature",
        ///             TfsAuthenticationNtlm()),
        ///         repoRoot);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory(CakeAliasConstants.CodeAnalysisProviderCakeAliasCategory)]
        public static ICodeAnalysisProvider InspectCode(
            this ICakeContext context,
            InspectCodeSettings settings)
        {
            context.NotNull(nameof(context));
            settings.NotNull(nameof(settings));

            return new InspectCodeProvider(context.Log, settings);
        }
    }
}

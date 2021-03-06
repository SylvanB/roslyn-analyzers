// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Analyzer.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.NetCore.Analyzers.Security.Helpers;

namespace Microsoft.NetCore.Analyzers.Security
{
    /// <summary>
    /// For detecting deserialization with <see cref="T:System.Data.DataSet"/>.
    /// </summary>
    [SuppressMessage("Documentation", "CA1200:Avoid using cref tags with a prefix", Justification = "The comment references a type that is not referenced by this compilation.")]
    [DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
    internal class DoNotUseDataSetReadXml : DoNotUseInsecureDeserializerMethodsBase
    {
        internal static readonly DiagnosticDescriptor RealMethodUsedDescriptor =
            SecurityHelpers.CreateDiagnosticDescriptor(
                "CA2351",
                nameof(MicrosoftNetCoreAnalyzersResources.DataSetReadXmlTitle),
                nameof(MicrosoftNetCoreAnalyzersResources.DataSetReadXmlMessage),
                RuleLevel.Disabled,
                isPortedFxCopRule: false,
                isDataflowRule: false);

        protected override string DeserializerTypeMetadataName =>
            WellKnownTypeNames.SystemDataDataSet;

        protected override ImmutableHashSet<string> DeserializationMethodNames =>
            SecurityHelpers.DataSetDeserializationMethods;

        protected override DiagnosticDescriptor MethodUsedDescriptor => RealMethodUsedDescriptor;
    }
}

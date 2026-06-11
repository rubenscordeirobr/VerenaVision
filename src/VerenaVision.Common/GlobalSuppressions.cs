//CA1032 - 
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "CA1716:Identifiers should not match keywords",
    Justification = "<Pending>",
    Scope = "type",
    Target = "~T:VerenaVision.Common.Error")]

[assembly: SuppressMessage("Design", "CA1032:Implement standard exception constructors",
    Justification = "<Pending>",
    Scope = "module")]

[assembly: SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "<Pending>", Scope = "member", Target = "~P:VerenaVision.Common.IResultValue.Error")]
[assembly: SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "<Pending>", Scope = "member", Target = "~M:VerenaVision.Common.Result`1.GetRequiredValue~`0")]

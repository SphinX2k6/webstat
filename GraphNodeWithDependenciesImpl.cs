using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x020034CB RID: 13515
[NullableContext(1)]
[Nullable(0)]
public class GraphNodeWithDependenciesImpl : IGraphNodeWithDependencies, IGraphNode
{
	// Token: 0x170026C6 RID: 9926
	// (get) Token: 0x0601C8F2 RID: 116978 RVA: 0x0088FC4C File Offset: 0x0088DE4C
	// (set) Token: 0x0601C8F3 RID: 116979 RVA: 0x0088FC54 File Offset: 0x0088DE54
	public Func<UniTask> Run { get; set; }

	// Token: 0x170026C7 RID: 9927
	// (get) Token: 0x0601C8F4 RID: 116980 RVA: 0x0088FC5D File Offset: 0x0088DE5D
	// (set) Token: 0x0601C8F5 RID: 116981 RVA: 0x0088FC65 File Offset: 0x0088DE65
	public int? Priority { get; set; }

	// Token: 0x170026C8 RID: 9928
	// (get) Token: 0x0601C8F6 RID: 116982 RVA: 0x0088FC6E File Offset: 0x0088DE6E
	// (set) Token: 0x0601C8F7 RID: 116983 RVA: 0x0088FC76 File Offset: 0x0088DE76
	public HashSet<string> DependsOn { get; set; }

	// Token: 0x170026C9 RID: 9929
	// (get) Token: 0x0601C8F8 RID: 116984 RVA: 0x0088FC7F File Offset: 0x0088DE7F
	// (set) Token: 0x0601C8F9 RID: 116985 RVA: 0x0088FC87 File Offset: 0x0088DE87
	public HashSet<string> DependedOnBy { get; set; }

	// Token: 0x170026CA RID: 9930
	// (get) Token: 0x0601C8FA RID: 116986 RVA: 0x0088FC90 File Offset: 0x0088DE90
	// (set) Token: 0x0601C8FB RID: 116987 RVA: 0x0088FC98 File Offset: 0x0088DE98
	public bool Failed { get; set; }
}

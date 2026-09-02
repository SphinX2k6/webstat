using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using Cysharp.Threading.Tasks;

// Token: 0x02002240 RID: 8768
[NullableContext(1)]
[Nullable(0)]
public class MapMarkOperation : IMapMarkOperation, IMapOperation
{
	// Token: 0x17001467 RID: 5223
	// (get) Token: 0x060108CE RID: 67790 RVA: 0x004870FD File Offset: 0x004852FD
	// (set) Token: 0x060108CF RID: 67791 RVA: 0x00487105 File Offset: 0x00485305
	[Nullable(2)]
	public string OpName { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001468 RID: 5224
	// (get) Token: 0x060108D0 RID: 67792 RVA: 0x0048710E File Offset: 0x0048530E
	// (set) Token: 0x060108D1 RID: 67793 RVA: 0x00487116 File Offset: 0x00485316
	public EMapOperationType Type { get; set; }

	// Token: 0x17001469 RID: 5225
	// (get) Token: 0x060108D2 RID: 67794 RVA: 0x0048711F File Offset: 0x0048531F
	// (set) Token: 0x060108D3 RID: 67795 RVA: 0x00487127 File Offset: 0x00485327
	public Func<bool> IsValidate { get; set; }

	// Token: 0x1700146A RID: 5226
	// (get) Token: 0x060108D4 RID: 67796 RVA: 0x00487130 File Offset: 0x00485330
	// (set) Token: 0x060108D5 RID: 67797 RVA: 0x00487138 File Offset: 0x00485338
	public Func<UniTask> Execute { get; set; }

	// Token: 0x1700146B RID: 5227
	// (get) Token: 0x060108D6 RID: 67798 RVA: 0x00487141 File Offset: 0x00485341
	// (set) Token: 0x060108D7 RID: 67799 RVA: 0x00487149 File Offset: 0x00485349
	public EMarkType MarkType { get; set; }

	// Token: 0x1700146C RID: 5228
	// (get) Token: 0x060108D8 RID: 67800 RVA: 0x00487152 File Offset: 0x00485352
	// (set) Token: 0x060108D9 RID: 67801 RVA: 0x0048715A File Offset: 0x0048535A
	public int? MarkId { get; set; }
}

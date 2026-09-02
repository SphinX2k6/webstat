using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02000D61 RID: 3425
[NullableContext(2)]
[Nullable(0)]
public class AnsInstanceState
{
	// Token: 0x17000400 RID: 1024
	// (get) Token: 0x06004952 RID: 18770 RVA: 0x0009D85F File Offset: 0x0009BA5F
	// (set) Token: 0x06004953 RID: 18771 RVA: 0x0009D867 File Offset: 0x0009BA67
	public bool IsListening { get; set; }

	// Token: 0x17000401 RID: 1025
	// (get) Token: 0x06004954 RID: 18772 RVA: 0x0009D870 File Offset: 0x0009BA70
	// (set) Token: 0x06004955 RID: 18773 RVA: 0x0009D878 File Offset: 0x0009BA78
	public TsBaseCharacter Owner { get; set; }

	// Token: 0x17000402 RID: 1026
	// (get) Token: 0x06004956 RID: 18774 RVA: 0x0009D881 File Offset: 0x0009BA81
	// (set) Token: 0x06004957 RID: 18775 RVA: 0x0009D889 File Offset: 0x0009BA89
	public bool IsGameplayOpened { get; set; }

	// Token: 0x17000403 RID: 1027
	// (get) Token: 0x06004958 RID: 18776 RVA: 0x0009D892 File Offset: 0x0009BA92
	// (set) Token: 0x06004959 RID: 18777 RVA: 0x0009D89A File Offset: 0x0009BA9A
	public double? StartServerTimeStamp { get; set; }

	// Token: 0x17000404 RID: 1028
	// (get) Token: 0x0600495A RID: 18778 RVA: 0x0009D8A3 File Offset: 0x0009BAA3
	// (set) Token: 0x0600495B RID: 18779 RVA: 0x0009D8AB File Offset: 0x0009BAAB
	public TInputHandle<InputDistributeDefine.EActionType> OnActionCallback { get; set; }

	// Token: 0x04001488 RID: 5256
	[Nullable(1)]
	public List<string> BoundActionNames = new List<string>();

	// Token: 0x04001489 RID: 5257
	[Nullable(1)]
	public List<int> ExternalInteractIds = new List<int>();
}

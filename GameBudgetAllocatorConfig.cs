using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000BBF RID: 3007
[NullableContext(1)]
[Nullable(0)]
public class GameBudgetAllocatorConfig
{
	// Token: 0x1700009D RID: 157
	// (get) Token: 0x060030E7 RID: 12519 RVA: 0x0001B0A7 File Offset: 0x000192A7
	// (set) Token: 0x060030E8 RID: 12520 RVA: 0x0001B0AF File Offset: 0x000192AF
	public TsGameBudgetAllocatorTickIntervalDetailConfig Default
	{
		get
		{
			return this._Default;
		}
		set
		{
			this._Default = value;
			this.ConfigMap["Default"] = value;
		}
	}

	// Token: 0x1700009E RID: 158
	// (get) Token: 0x060030E9 RID: 12521 RVA: 0x0001B0C9 File Offset: 0x000192C9
	// (set) Token: 0x060030EA RID: 12522 RVA: 0x0001B0D1 File Offset: 0x000192D1
	public TsGameBudgetAllocatorTickIntervalDetailConfig Normal_Render
	{
		get
		{
			return this._Normal_Render;
		}
		set
		{
			this._Normal_Render = value;
			this.ConfigMap["Normal_Render"] = value;
		}
	}

	// Token: 0x1700009F RID: 159
	// (get) Token: 0x060030EB RID: 12523 RVA: 0x0001B0EB File Offset: 0x000192EB
	// (set) Token: 0x060030EC RID: 12524 RVA: 0x0001B0F3 File Offset: 0x000192F3
	public TsGameBudgetAllocatorTickIntervalDetailConfig Normal_NotRendered
	{
		get
		{
			return this._Normal_NotRendered;
		}
		set
		{
			this._Normal_NotRendered = value;
			this.ConfigMap["Normal_NotRendered"] = value;
		}
	}

	// Token: 0x170000A0 RID: 160
	// (get) Token: 0x060030ED RID: 12525 RVA: 0x0001B10D File Offset: 0x0001930D
	// (set) Token: 0x060030EE RID: 12526 RVA: 0x0001B115 File Offset: 0x00019315
	public TsGameBudgetAllocatorTickIntervalDetailConfig Normal_Fighting
	{
		get
		{
			return this._Normal_Fighting;
		}
		set
		{
			this._Normal_Fighting = value;
			this.ConfigMap["Normal_Fighting"] = value;
		}
	}

	// Token: 0x170000A1 RID: 161
	// (get) Token: 0x060030EF RID: 12527 RVA: 0x0001B12F File Offset: 0x0001932F
	// (set) Token: 0x060030F0 RID: 12528 RVA: 0x0001B137 File Offset: 0x00019337
	public TsGameBudgetAllocatorTickIntervalDetailConfig Fighting_Rendered
	{
		get
		{
			return this._Fighting_Rendered;
		}
		set
		{
			this._Fighting_Rendered = value;
			this.ConfigMap["Fighting_Rendered"] = value;
		}
	}

	// Token: 0x170000A2 RID: 162
	// (get) Token: 0x060030F1 RID: 12529 RVA: 0x0001B151 File Offset: 0x00019351
	// (set) Token: 0x060030F2 RID: 12530 RVA: 0x0001B159 File Offset: 0x00019359
	public TsGameBudgetAllocatorTickIntervalDetailConfig Fighting_NotRendered
	{
		get
		{
			return this._Fighting_NotRendered;
		}
		set
		{
			this._Fighting_NotRendered = value;
			this.ConfigMap["Fighting_NotRendered"] = value;
		}
	}

	// Token: 0x170000A3 RID: 163
	// (get) Token: 0x060030F3 RID: 12531 RVA: 0x0001B173 File Offset: 0x00019373
	// (set) Token: 0x060030F4 RID: 12532 RVA: 0x0001B17B File Offset: 0x0001937B
	public TsGameBudgetAllocatorTickIntervalDetailConfig Fighting_Fighting
	{
		get
		{
			return this._Fighting_Fighting;
		}
		set
		{
			this._Fighting_Fighting = value;
			this.ConfigMap["Fighting_Fighting"] = value;
		}
	}

	// Token: 0x170000A4 RID: 164
	// (get) Token: 0x060030F5 RID: 12533 RVA: 0x0001B195 File Offset: 0x00019395
	// (set) Token: 0x060030F6 RID: 12534 RVA: 0x0001B19D File Offset: 0x0001939D
	public TsGameBudgetAllocatorTickIntervalDetailConfig Cutscene_Rendered
	{
		get
		{
			return this._Cutscene_Rendered;
		}
		set
		{
			this._Cutscene_Rendered = value;
			this.ConfigMap["Cutscene_Rendered"] = value;
		}
	}

	// Token: 0x170000A5 RID: 165
	// (get) Token: 0x060030F7 RID: 12535 RVA: 0x0001B1B7 File Offset: 0x000193B7
	// (set) Token: 0x060030F8 RID: 12536 RVA: 0x0001B1BF File Offset: 0x000193BF
	public TsGameBudgetAllocatorTickIntervalDetailConfig Cutscene_NotRendered
	{
		get
		{
			return this._Cutscene_NotRendered;
		}
		set
		{
			this._Cutscene_NotRendered = value;
			this.ConfigMap["Cutscene_NotRendered"] = value;
		}
	}

	// Token: 0x170000A6 RID: 166
	// (get) Token: 0x060030F9 RID: 12537 RVA: 0x0001B1D9 File Offset: 0x000193D9
	// (set) Token: 0x060030FA RID: 12538 RVA: 0x0001B1E1 File Offset: 0x000193E1
	public TsGameBudgetAllocatorTickIntervalDetailConfig Cutscene_Fighting
	{
		get
		{
			return this._Cutscene_Fighting;
		}
		set
		{
			this._Cutscene_Fighting = value;
			this.ConfigMap["Cutscene_Fighting"] = value;
		}
	}

	// Token: 0x170000A7 RID: 167
	public TsGameBudgetAllocatorTickIntervalDetailConfig this[string key]
	{
		get
		{
			return this.ConfigMap[key];
		}
	}

	// Token: 0x170000A8 RID: 168
	// (get) Token: 0x060030FC RID: 12540 RVA: 0x0001B209 File Offset: 0x00019409
	public Dictionary<string, TsGameBudgetAllocatorTickIntervalDetailConfig>.KeyCollection Keys
	{
		get
		{
			return this.ConfigMap.Keys;
		}
	}

	// Token: 0x0400042A RID: 1066
	[Nullable(2)]
	private TsGameBudgetAllocatorTickIntervalDetailConfig _Default;

	// Token: 0x0400042B RID: 1067
	[Nullable(2)]
	private TsGameBudgetAllocatorTickIntervalDetailConfig _Normal_Render;

	// Token: 0x0400042C RID: 1068
	[Nullable(2)]
	private TsGameBudgetAllocatorTickIntervalDetailConfig _Normal_NotRendered;

	// Token: 0x0400042D RID: 1069
	[Nullable(2)]
	private TsGameBudgetAllocatorTickIntervalDetailConfig _Normal_Fighting;

	// Token: 0x0400042E RID: 1070
	[Nullable(2)]
	private TsGameBudgetAllocatorTickIntervalDetailConfig _Fighting_Rendered;

	// Token: 0x0400042F RID: 1071
	[Nullable(2)]
	private TsGameBudgetAllocatorTickIntervalDetailConfig _Fighting_NotRendered;

	// Token: 0x04000430 RID: 1072
	[Nullable(2)]
	private TsGameBudgetAllocatorTickIntervalDetailConfig _Fighting_Fighting;

	// Token: 0x04000431 RID: 1073
	[Nullable(2)]
	public TsGameBudgetAllocatorTickIntervalDetailConfig _Cutscene_Rendered;

	// Token: 0x04000432 RID: 1074
	[Nullable(2)]
	public TsGameBudgetAllocatorTickIntervalDetailConfig _Cutscene_NotRendered;

	// Token: 0x04000433 RID: 1075
	[Nullable(2)]
	public TsGameBudgetAllocatorTickIntervalDetailConfig _Cutscene_Fighting;

	// Token: 0x04000434 RID: 1076
	private readonly Dictionary<string, TsGameBudgetAllocatorTickIntervalDetailConfig> ConfigMap = new Dictionary<string, TsGameBudgetAllocatorTickIntervalDetailConfig>();
}

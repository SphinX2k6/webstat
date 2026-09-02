using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200260C RID: 9740
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BattleQteModel : ModelBase<BattleQteModel>
{
	// Token: 0x0601317B RID: 78203 RVA: 0x0054B705 File Offset: 0x00549905
	protected override bool OnInit()
	{
		if (!Singleton<EventSystem>.Instance.Has<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd)))
		{
			Singleton<EventSystem>.Instance.Add<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
		}
		return true;
	}

	// Token: 0x0601317C RID: 78204 RVA: 0x0054B741 File Offset: 0x00549941
	protected override bool OnClear()
	{
		if (Singleton<EventSystem>.Instance.Has<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd)))
		{
			Singleton<EventSystem>.Instance.Remove<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
		}
		return true;
	}

	// Token: 0x0601317D RID: 78205 RVA: 0x0054B780 File Offset: 0x00549980
	private void OnCommonQteEnd(int? commonQteHandleId)
	{
		BattleQteContext battleQteContext = this.GetBattleQteContext(this.GetBattleQteHandleId());
		if (battleQteContext != null)
		{
			int? num = commonQteHandleId;
			int commonQteHandleId2 = battleQteContext.CommonQteHandleId;
			if (num.GetValueOrDefault() == commonQteHandleId2 & num != null)
			{
				Dictionary<int, BattleQteContext> battleContexts = this.BattleContexts;
				if (battleContexts != null)
				{
					battleContexts.Remove(battleQteContext.BattleQteHandleId);
				}
				this.ClearBattleQteHandleId();
			}
		}
	}

	// Token: 0x0601317E RID: 78206 RVA: 0x0054B7D8 File Offset: 0x005499D8
	protected override bool OnLeaveLevel()
	{
		Dictionary<int, BattleQteContext> battleContexts = this.BattleContexts;
		if (battleContexts != null)
		{
			battleContexts.Clear();
		}
		this.BattleQteDt = null;
		return true;
	}

	// Token: 0x0601317F RID: 78207 RVA: 0x0054B7F4 File Offset: 0x005499F4
	[return: Nullable(2)]
	public BattleQteContext CreateBattleQteContext(int battleQteId, long messageId, EntityHandle entityHandle, EBattleQteSource source)
	{
		SBattleQte battleQteConfig = this.GetBattleQteConfig(battleQteId);
		if (battleQteConfig == null)
		{
			return null;
		}
		BattleQteContext battleQteContext = new BattleQteContext();
		int battleHandleIdCounter = this.BattleHandleIdCounter;
		this.BattleHandleIdCounter = battleHandleIdCounter + 1;
		battleQteContext.BattleQteHandleId = battleHandleIdCounter;
		battleQteContext.CommonQteId = battleQteConfig.QteId;
		battleQteContext.BattleQteId = battleQteId;
		battleQteContext.MessageId = new long?(messageId);
		battleQteContext.EntityHandle = entityHandle;
		battleQteContext.BattleQteSource = new EBattleQteSource?(source);
		return battleQteContext;
	}

	// Token: 0x06013180 RID: 78208 RVA: 0x0054B864 File Offset: 0x00549A64
	[NullableContext(2)]
	public SBattleQte GetBattleQteConfig(int battleQteId)
	{
		if (this.BattleQteDt == null)
		{
			this.BattleQteDt = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Qte/DT_BattleQte.DT_BattleQte");
		}
		SBattleQte dataTableRow = DataTableUtil.GetDataTableRow<SBattleQte>(this.BattleQteDt, battleQteId.ToString());
		if (dataTableRow == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CommonQte;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "找不到战斗QTE配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BattleQteId", battleQteId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return dataTableRow;
	}

	// Token: 0x06013181 RID: 78209 RVA: 0x0054B8D8 File Offset: 0x00549AD8
	public void SetCurrentBattleQte(BattleQteContext context)
	{
		this.BattleHandleId = context.BattleQteHandleId;
		if (this.BattleContexts == null)
		{
			this.BattleContexts = new Dictionary<int, BattleQteContext>();
		}
		this.BattleContexts[context.BattleQteHandleId] = context;
	}

	// Token: 0x06013182 RID: 78210 RVA: 0x0054B90B File Offset: 0x00549B0B
	public int GetBattleQteHandleId()
	{
		return this.BattleHandleId;
	}

	// Token: 0x06013183 RID: 78211 RVA: 0x0054B913 File Offset: 0x00549B13
	public void ClearBattleQteHandleId()
	{
		this.BattleHandleId = -1;
	}

	// Token: 0x06013184 RID: 78212 RVA: 0x0054B91C File Offset: 0x00549B1C
	[NullableContext(2)]
	public BattleQteContext GetBattleQteContext(int qteHandleId)
	{
		BattleQteContext result;
		if (this.BattleContexts != null && this.BattleContexts.TryGetValue(qteHandleId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x040094FF RID: 38143
	private const string DT_BATTLE_QTE_PATH = "/Game/Aki/Data/Qte/DT_BattleQte.DT_BattleQte";

	// Token: 0x04009500 RID: 38144
	private int BattleHandleIdCounter;

	// Token: 0x04009501 RID: 38145
	private int BattleHandleId;

	// Token: 0x04009502 RID: 38146
	[Nullable(2)]
	private UDataTable BattleQteDt;

	// Token: 0x04009503 RID: 38147
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, BattleQteContext> BattleContexts;
}

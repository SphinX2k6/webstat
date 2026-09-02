using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.UI;
using UnrealEngine;

// Token: 0x02002357 RID: 9047
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PanelQteModel : ModelBase<PanelQteModel>
{
	// Token: 0x06011492 RID: 70802 RVA: 0x004C1392 File Offset: 0x004BF592
	protected override bool OnInit()
	{
		this.IsInQte = new bool?(false);
		this.HandleId = new int?(0);
		this.TimeDilation.Init();
		this.ResultHandler = new PanelQteResultHandler();
		return true;
	}

	// Token: 0x06011493 RID: 70803 RVA: 0x004C13C3 File Offset: 0x004BF5C3
	protected override bool OnLeaveLevel()
	{
		this.CommonDt = null;
		return true;
	}

	// Token: 0x06011494 RID: 70804 RVA: 0x004C13CD File Offset: 0x004BF5CD
	protected override bool OnClear()
	{
		this.IsInQte = null;
		this.HandleId = null;
		this.TimeDilation.Clear();
		this.ResultHandler = null;
		return true;
	}

	// Token: 0x06011495 RID: 70805 RVA: 0x004C13FC File Offset: 0x004BF5FC
	[NullableContext(1)]
	public int StartQte(PanelQteContext context)
	{
		this.HandleId = new int?(this.HandleId.GetValueOrDefault() + 1);
		this.IsInQte = new bool?(true);
		this.Context = context;
		context.QteHandleId = this.HandleId.Value;
		this.TimeDilation.Start(context);
		if (context.Config.Duration > 0f)
		{
			this.LeftTime = context.Config.Duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			Number worldTimeDilation = this.TimeDilation.GetWorldTimeDilation();
			if (worldTimeDilation != 0)
			{
				this.EndWorldTime = Singleton<Time>.Instance.WorldTime + this.LeftTime * worldTimeDilation;
			}
		}
		else
		{
			this.LeftTime = 0;
			this.EndWorldTime = 0;
		}
		return this.HandleId.Value;
	}

	// Token: 0x06011496 RID: 70806 RVA: 0x004C14EC File Offset: 0x004BF6EC
	public bool StopQte(int handleId)
	{
		if (this.IsInQte.GetValueOrDefault())
		{
			int? handleId2 = this.HandleId;
			if (handleId2.GetValueOrDefault() == handleId & handleId2 != null)
			{
				this.IsInQte = new bool?(false);
				this.TimeDilation.Stop();
				return true;
			}
		}
		return false;
	}

	// Token: 0x06011497 RID: 70807 RVA: 0x004C153D File Offset: 0x004BF73D
	public void ForceStopQte()
	{
		if (this.HandleId != null)
		{
			this.StopQte(this.HandleId.Value);
		}
	}

	// Token: 0x06011498 RID: 70808 RVA: 0x004C155E File Offset: 0x004BF75E
	public PanelQteContext GetContext()
	{
		return this.Context;
	}

	// Token: 0x06011499 RID: 70809 RVA: 0x004C1566 File Offset: 0x004BF766
	public Number GetWorldTimeDilation()
	{
		return this.TimeDilation.GetWorldTimeDilation();
	}

	// Token: 0x0601149A RID: 70810 RVA: 0x004C1573 File Offset: 0x004BF773
	public Number GetLeftTime()
	{
		return this.LeftTime;
	}

	// Token: 0x0601149B RID: 70811 RVA: 0x004C157C File Offset: 0x004BF77C
	public Number GetLeftTimeNoScale()
	{
		if (this.LeftTime <= 0)
		{
			return 0;
		}
		if (!this.IsInQte.GetValueOrDefault())
		{
			return 0;
		}
		Number worldTimeDilation = this.TimeDilation.GetWorldTimeDilation();
		if (worldTimeDilation == 0)
		{
			return this.LeftTime;
		}
		return this.LeftTime / worldTimeDilation;
	}

	// Token: 0x0601149C RID: 70812 RVA: 0x004C15E4 File Offset: 0x004BF7E4
	public void ResetLeftTime(int handleId)
	{
		int? handleId2 = this.HandleId;
		if (!(handleId2.GetValueOrDefault() == handleId & handleId2 != null))
		{
			return;
		}
		if (this.LeftTime > 0)
		{
			Number worldTimeDilation = this.TimeDilation.GetWorldTimeDilation();
			if (worldTimeDilation != 0)
			{
				this.EndWorldTime = Singleton<Time>.Instance.WorldTime + this.LeftTime * worldTimeDilation;
				return;
			}
		}
		else
		{
			this.EndWorldTime = 0;
		}
	}

	// Token: 0x0601149D RID: 70813 RVA: 0x004C1670 File Offset: 0x004BF870
	public void UpdateTime(float delta)
	{
		if (this.LeftTime <= 0)
		{
			return;
		}
		if (!this.IsInQte.GetValueOrDefault())
		{
			return;
		}
		if (this.TimeDilation.GetWorldTimeDilation() == 0)
		{
			this.LeftTime -= delta;
		}
		else
		{
			this.LeftTime = this.EndWorldTime - Singleton<Time>.Instance.WorldTime;
		}
		if (this.LeftTime <= 0 && this.HandleId != null)
		{
			ControllerBase<PanelQteController>.Instance.StopQte(this.HandleId.Value, false);
		}
	}

	// Token: 0x0601149E RID: 70814 RVA: 0x004C1728 File Offset: 0x004BF928
	public SPanelQte GetPanelQteConfig(int qteId)
	{
		if (this.CommonDt == null)
		{
			this.CommonDt = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Fight/UI/DT_PanelQte.DT_PanelQte");
		}
		SPanelQte dataTableRow = DataTableUtil.GetDataTableRow<SPanelQte>(this.CommonDt, qteId.ToString());
		if (dataTableRow == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PanelQte;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "找不到界面QTE配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("qteId", qteId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return dataTableRow;
	}

	// Token: 0x0601149F RID: 70815 RVA: 0x004C179C File Offset: 0x004BF99C
	public bool SetQteResult(int handleId, bool success)
	{
		int? handleId2 = this.HandleId;
		if (!(handleId2.GetValueOrDefault() == handleId & handleId2 != null))
		{
			return false;
		}
		this.Context.Success = success;
		return true;
	}

	// Token: 0x060114A0 RID: 70816 RVA: 0x004C17D5 File Offset: 0x004BF9D5
	public void HandleResult()
	{
		this.ResultHandler.Handle(this.Context);
	}

	// Token: 0x060114A1 RID: 70817 RVA: 0x004C17E8 File Offset: 0x004BF9E8
	public bool IsQteSuccess()
	{
		PanelQteContext context = this.Context;
		return context != null && context.Success;
	}

	// Token: 0x040087CD RID: 34765
	[Nullable(1)]
	private readonly PanelQteTimeDilation TimeDilation = new PanelQteTimeDilation();

	// Token: 0x040087CE RID: 34766
	public bool? IsInQte;

	// Token: 0x040087CF RID: 34767
	private int? HandleId;

	// Token: 0x040087D0 RID: 34768
	private Number LeftTime = 0;

	// Token: 0x040087D1 RID: 34769
	private Number EndWorldTime = 0;

	// Token: 0x040087D2 RID: 34770
	private UDataTable CommonDt;

	// Token: 0x040087D3 RID: 34771
	private PanelQteContext Context;

	// Token: 0x040087D4 RID: 34772
	private PanelQteResultHandler ResultHandler;

	// Token: 0x040087D5 RID: 34773
	public bool IsHideAllBattleUi;

	// Token: 0x040087D6 RID: 34774
	public int[] HideBattleUiChildren;

	// Token: 0x040087D7 RID: 34775
	public bool DisableFightInput;

	// Token: 0x040087D8 RID: 34776
	public EntityHandle CurRoleEntity;
}

using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;

// Token: 0x02002616 RID: 9750
[NullableContext(2)]
[Nullable(0)]
public class CommonQteSingleClickContext : CommonQteContextBase
{
	// Token: 0x06013249 RID: 78409 RVA: 0x0054FC49 File Offset: 0x0054DE49
	public CommonQteSingleClickContext()
	{
		this.Type = new ECommonQteContextType?(ECommonQteContextType.SingleButtonSingleClick);
	}

	// Token: 0x0601324A RID: 78410 RVA: 0x0054FC64 File Offset: 0x0054DE64
	[NullableContext(1)]
	protected override void OnSetConfig(SCommonQte config)
	{
		this.TargetCount = 1;
	}

	// Token: 0x0601324B RID: 78411 RVA: 0x0054FC70 File Offset: 0x0054DE70
	protected override void OnResponse()
	{
		if (this.Config == null)
		{
			return;
		}
		if (!base.IsPending() && !base.IsPendingSuccess())
		{
			return;
		}
		if (base.IsPending())
		{
			ControllerBase<CommonQteController>.Instance.PlayGamepadShake();
			this.ResponseCount++;
		}
		this.CheckQteConditionAndDoSuccess();
	}

	// Token: 0x0601324C RID: 78412 RVA: 0x0054FCC4 File Offset: 0x0054DEC4
	protected override void OnUpdateTime(float delta)
	{
		if (this.Config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CommonQte;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "Context中获取不到Config";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QteId", this.QteId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<CommonQteController>.Instance.StopCurrentQte();
			return;
		}
		this.PassTime += delta;
		if (this.CheckQteConditionAndDoSuccess())
		{
			return;
		}
		if (!this.IsPermanent && this.PassTime > this.Duration)
		{
			base.QteFail();
		}
	}

	// Token: 0x0601324D RID: 78413 RVA: 0x0054FD54 File Offset: 0x0054DF54
	protected override string OnGetAction(int? index = null)
	{
		if (this.Config == null)
		{
			return null;
		}
		SCommonQteButton uiconfig = this.Config.BaseConfig.SingleClickConfig.UIConfig;
		return CommonQteContextBase.GetQteActionNameByActionId((uiconfig.ActionId > 0) ? uiconfig.ActionId : ((int)uiconfig.Action), new int?(this.QteId));
	}

	// Token: 0x0601324E RID: 78414 RVA: 0x0054FDB3 File Offset: 0x0054DFB3
	[PreserveBaseOverrides]
	protected new virtual SCommonQte_SingleClick OnGetUiConfig()
	{
		if (this.Config == null)
		{
			return null;
		}
		return this.Config.BaseConfig.SingleClickConfig;
	}

	// Token: 0x0601324F RID: 78415 RVA: 0x0054FDD5 File Offset: 0x0054DFD5
	public override bool CheckQteConditionMatch()
	{
		return this.ResponseCount >= this.TargetCount;
	}

	// Token: 0x06013250 RID: 78416 RVA: 0x0054FDE8 File Offset: 0x0054DFE8
	public override bool IsAttachToActor()
	{
		SCommonQte config = this.Config;
		return config != null && config.BaseConfig.SingleClickConfig.IsAttachToActor;
	}

	// Token: 0x06013251 RID: 78417 RVA: 0x0054FE08 File Offset: 0x0054E008
	public override SCommonQte_Attach? GetAttachConfig()
	{
		SCommonQte config = this.Config;
		if (config == null)
		{
			return null;
		}
		return new SCommonQte_Attach?(config.BaseConfig.SingleClickConfig.AttachConfig);
	}

	// Token: 0x04009567 RID: 38247
	public int ResponseCount;

	// Token: 0x04009568 RID: 38248
	public int TargetCount = -1;
}

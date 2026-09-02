using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;

// Token: 0x02002615 RID: 9749
[NullableContext(2)]
[Nullable(0)]
public class CommonQteSelectOptionContext : CommonQteContextBase
{
	// Token: 0x0601323E RID: 78398 RVA: 0x0054F9E4 File Offset: 0x0054DBE4
	public CommonQteSelectOptionContext()
	{
		this.Type = new ECommonQteContextType?(ECommonQteContextType.SelectOption);
	}

	// Token: 0x0601323F RID: 78399 RVA: 0x0054FA0D File Offset: 0x0054DC0D
	[NullableContext(1)]
	protected override void OnSetConfig(SCommonQte config)
	{
		this.TargetCount = 1;
		this.DefaultOption = config.BaseConfig.SelectOptionConfig.DefaultOption;
	}

	// Token: 0x06013240 RID: 78400 RVA: 0x0054FA2C File Offset: 0x0054DC2C
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
			this.ResponseCount++;
		}
		if (this.CheckQteConditionMatch())
		{
			if (this.PassTime < this.LeastDuration)
			{
				base.QtePendingSuccess();
				return;
			}
			base.QteSuccess();
		}
	}

	// Token: 0x06013241 RID: 78401 RVA: 0x0054FA92 File Offset: 0x0054DC92
	protected override void OnQteFail()
	{
		this.SelectOption = this.DefaultOption;
	}

	// Token: 0x06013242 RID: 78402 RVA: 0x0054FAA0 File Offset: 0x0054DCA0
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
		if (!this.CheckQteConditionMatch())
		{
			if (!this.IsPermanent && this.PassTime > this.Duration)
			{
				base.QteFail();
			}
			return;
		}
		if (this.PassTime < this.LeastDuration)
		{
			base.QtePendingSuccess();
			return;
		}
		base.QteSuccess();
	}

	// Token: 0x06013243 RID: 78403 RVA: 0x0054FB48 File Offset: 0x0054DD48
	public override string GetAction(int? index = null)
	{
		return this.OnGetAction(index);
	}

	// Token: 0x06013244 RID: 78404 RVA: 0x0054FB54 File Offset: 0x0054DD54
	protected override string OnGetAction(int? index)
	{
		if (this.Config == null)
		{
			return null;
		}
		SCommonQteButton scommonQteButton = this.Config.BaseConfig.SelectOptionConfig.UIConfigList.Get(index.GetValueOrDefault());
		return CommonQteContextBase.GetQteActionNameByActionId((scommonQteButton.ActionId > 0) ? scommonQteButton.ActionId : ((int)scommonQteButton.Action), new int?(this.QteId));
	}

	// Token: 0x06013245 RID: 78405 RVA: 0x0054FBBF File Offset: 0x0054DDBF
	[PreserveBaseOverrides]
	protected new virtual SCommonQte_SelectOption OnGetUiConfig()
	{
		if (this.Config == null)
		{
			return null;
		}
		return this.Config.BaseConfig.SelectOptionConfig;
	}

	// Token: 0x06013246 RID: 78406 RVA: 0x0054FBE1 File Offset: 0x0054DDE1
	public override bool CheckQteConditionMatch()
	{
		return this.ResponseCount >= this.TargetCount;
	}

	// Token: 0x06013247 RID: 78407 RVA: 0x0054FBF4 File Offset: 0x0054DDF4
	public override bool IsAttachToActor()
	{
		SCommonQte config = this.Config;
		return config != null && config.BaseConfig.SelectOptionConfig.IsAttachToActor;
	}

	// Token: 0x06013248 RID: 78408 RVA: 0x0054FC14 File Offset: 0x0054DE14
	public override SCommonQte_Attach? GetAttachConfig()
	{
		SCommonQte config = this.Config;
		if (config == null)
		{
			return null;
		}
		return new SCommonQte_Attach?(config.BaseConfig.SelectOptionConfig.AttachConfig);
	}

	// Token: 0x04009563 RID: 38243
	public int ResponseCount;

	// Token: 0x04009564 RID: 38244
	public int TargetCount = -1;

	// Token: 0x04009565 RID: 38245
	public int SelectOption = -1;

	// Token: 0x04009566 RID: 38246
	public int DefaultOption = -1;
}

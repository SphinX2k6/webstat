using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002513 RID: 9491
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MainPhantomContent : GridProxyAbstract<IMainPhantomItemData>
{
	// Token: 0x060126B6 RID: 75446 RVA: 0x00510BA4 File Offset: 0x0050EDA4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickTogOption))
		};
	}

	// Token: 0x060126B7 RID: 75447 RVA: 0x00510C7C File Offset: 0x0050EE7C
	protected override UniTask OnBeforeStartAsync()
	{
		MainPhantomContent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MainPhantomContent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060126B8 RID: 75448 RVA: 0x00510CBF File Offset: 0x0050EEBF
	protected override void OnStart()
	{
		base.GetItem(5).SetUIActive(false);
		base.GetItem(4).SetUIActive(true);
	}

	// Token: 0x060126B9 RID: 75449 RVA: 0x00510CDB File Offset: 0x0050EEDB
	private void OnClickTogOption(EToggleState toggleState)
	{
		if (this.CurrentData == null)
		{
			return;
		}
		if (this.CurrentData.OnMainPhantomCallBack != null)
		{
			this.CurrentData.OnMainPhantomCallBack(this.CurrentData);
		}
	}

	// Token: 0x060126BA RID: 75450 RVA: 0x00510D0C File Offset: 0x0050EF0C
	[NullableContext(1)]
	public override void Refresh(IMainPhantomItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(data.Info.GetMonsterId());
		MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(calabashDevelopRewardByMonsterId.Value.MonsterInfoId);
		if (monsterInfoConfig != null)
		{
			base.SetTextureByPath(monsterInfoConfig.Value.Icon, base.GetTexture(1), null, null);
			string name = monsterInfoConfig.Value.Name;
			base.GetText(2).ShowTextNew(name);
		}
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data.Info.GetFetterGroupId());
		VisionMainFetterSuitItem visionMainFetterSuitItem = this.VisionMainFetterSuitItem;
		if (visionMainFetterSuitItem != null)
		{
			visionMainFetterSuitItem.Refresh(fetterGroupById, false, 0);
		}
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(data.Info.GetUsageText(), true);
		}
		bool flag = false;
		VisionMainSelectPhantomData currentSelectMainPhantom = data.CurrentSelectMainPhantom;
		if (currentSelectMainPhantom != null && currentSelectMainPhantom.MonsterId == data.Info.GetMonsterId() && currentSelectMainPhantom.FetterGroupId == data.Info.GetFetterGroupId())
		{
			flag = true;
		}
		base.GetExtendToggle(0).SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04008FBB RID: 36795
	private IMainPhantomItemData CurrentData;

	// Token: 0x04008FBC RID: 36796
	private VisionMainFetterSuitItem VisionMainFetterSuitItem;
}

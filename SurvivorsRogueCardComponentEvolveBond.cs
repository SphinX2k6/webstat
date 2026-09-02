using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002AD1 RID: 10961
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueCardComponentEvolveBond : SurvivorsRogueCardComponent
{
	// Token: 0x06015EB1 RID: 89777 RVA: 0x00616AE8 File Offset: 0x00614CE8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06015EB2 RID: 89778 RVA: 0x00616B44 File Offset: 0x00614D44
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueCardComponentEvolveBond.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueCardComponentEvolveBond.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015EB3 RID: 89779 RVA: 0x00616B87 File Offset: 0x00614D87
	protected override string OnGetResourceId()
	{
		return "UiItem_SurvivorsCardBind";
	}

	// Token: 0x06015EB4 RID: 89780 RVA: 0x00616B8E File Offset: 0x00614D8E
	public override ECardMountPos GetLayoutLevel()
	{
		return ECardMountPos.Bottom;
	}

	// Token: 0x06015EB5 RID: 89781 RVA: 0x00616B94 File Offset: 0x00614D94
	protected override void OnRefresh([Nullable(new byte[]
	{
		1,
		2
	})] params object[] params_)
	{
		int num = (params_.Length != 0 && params_[0] != null) ? ((int)params_[0]) : 0;
		if (num == 0)
		{
			this.SetActive(false);
			return;
		}
		SurvivorsWeapon? survivorsWeapon = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(num);
		if (survivorsWeapon == null)
		{
			this.SetActive(false);
			return;
		}
		this.AttributeItemCurrent.SetIsUp(false);
		this.AttributeItemCurrent.SetTextureIcon(survivorsWeapon.Value.Icon);
		int weaponBondOwnedWeaponId = ModelBase<SurvivorsRogueModel>.Instance.GainData.GetWeaponBondOwnedWeaponId(num);
		if (weaponBondOwnedWeaponId != 0)
		{
			SurvivorsWeapon? survivorsWeapon2 = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(weaponBondOwnedWeaponId);
			this.AttributeItemBind.SetIsUp(true);
			this.AttributeItemBind.SetTextureIcon(survivorsWeapon2.Value.Icon);
			this.AttributeItemBind.SetTextureIcon(survivorsWeapon2.Value.Icon);
			this.SetActive(true);
			return;
		}
		this.SetActive(false);
	}

	// Token: 0x0400A86C RID: 43116
	private SurvivorsRogueCardAttributeItem AttributeItemCurrent;

	// Token: 0x0400A86D RID: 43117
	private SurvivorsRogueCardAttributeItem AttributeItemBind;
}

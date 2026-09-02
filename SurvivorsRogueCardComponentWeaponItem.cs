using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002AD7 RID: 10967
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueCardComponentWeaponItem : SurvivorsRogueCardComponent
{
	// Token: 0x06015EC3 RID: 89795 RVA: 0x00616F44 File Offset: 0x00615144
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06015EC4 RID: 89796 RVA: 0x00616F9E File Offset: 0x0061519E
	protected override string OnGetResourceId()
	{
		return "UiItem_SurvivorsCardWeapon";
	}

	// Token: 0x06015EC5 RID: 89797 RVA: 0x00616FA5 File Offset: 0x006151A5
	public override ECardMountPos GetLayoutLevel()
	{
		return ECardMountPos.Center;
	}

	// Token: 0x06015EC6 RID: 89798 RVA: 0x00616FA8 File Offset: 0x006151A8
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueCardComponentWeaponItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueCardComponentWeaponItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015EC7 RID: 89799 RVA: 0x00616FEC File Offset: 0x006151EC
	protected override void OnRefresh([Nullable(new byte[]
	{
		1,
		2
	})] params object[] params_)
	{
		int weaponId = (params_.Length != 0 && params_[0] != null) ? ((int)params_[0]) : 0;
		int qualityId = (params_.Length > 1 && params_[1] != null) ? ((int)params_[1]) : 0;
		int? num = (params_.Length > 2 && params_[2] != null) ? ((int?)params_[2]) : null;
		SurvivorsWeapon? survivorsWeapon = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(weaponId);
		if (survivorsWeapon == null)
		{
			this.SetActive(false);
			return;
		}
		base.SetTextureByPath(ConfigBase<SurvivorsRogueConfig>.Instance.GetQualityConfig(qualityId).Value.WeaponBasePath, base.GetTexture(0), null, null);
		base.SetTextureShowUntilLoaded(survivorsWeapon.Value.Icon, base.GetTexture(1), null);
		if (num != null)
		{
			SurvivorsProperty? propertyConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetPropertyConfig(num.Value);
			this.AttributeItem.SetTextureIcon((propertyConfig != null) ? propertyConfig.GetValueOrDefault().Icon : null);
		}
		this.AttributeItem.SetActive(num != null);
		this.SetActive(true);
	}

	// Token: 0x0400A878 RID: 43128
	private SurvivorsRogueCardAttributeItem AttributeItem;
}

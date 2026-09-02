using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001028 RID: 4136
[NullableContext(2)]
[Nullable(0)]
public class DrinksRoleSelectItem : GridProxyAbstract<int>
{
	// Token: 0x06006B8A RID: 27530 RVA: 0x001C29DC File Offset: 0x001C0BDC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x06006B8B RID: 27531 RVA: 0x001C2A8E File Offset: 0x001C0C8E
	protected override void OnStart()
	{
		base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
	}

	// Token: 0x06006B8C RID: 27532 RVA: 0x001C2AAD File Offset: 0x001C0CAD
	public override void OnSelected(bool fireEvent)
	{
		if (this.IsSelectOnCb != null && this.ConfigId != -1)
		{
			this.SetSelected(this.IsSelectOnCb(this.ConfigId), false);
		}
	}

	// Token: 0x06006B8D RID: 27533 RVA: 0x001C2AD8 File Offset: 0x001C0CD8
	public override void Refresh(int configId, bool isSelected, int gridIndex)
	{
		this.ConfigId = configId;
		int roleId = ConfigBase<DrinksConfig>.Instance.GetInviteConfig(configId).Value.RoleId;
		base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.RoleHeadIconCircle, base.GetTexture(1), roleId, null, null);
		IDrinksMixRoleInfo drinksMixRoleInfo;
		ModelBase<SpringManorModel>.Instance.ActivityData.GetDrinksProgressMap().TryGetValue(roleId, out drinksMixRoleInfo);
		bool flag = ModelBase<DrinksModel>.Instance.CheckLevelIsUnlock(configId);
		bool flag2 = drinksMixRoleInfo != null && drinksMixRoleInfo.MaxLike;
		HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.DrinksUnlockLevelClicked, null);
		bool flag3 = (flag && !flag2 && (player == null || !player.Contains(configId))) || (drinksMixRoleInfo != null && drinksMixRoleInfo.FirstPass && !drinksMixRoleInfo.RewardGet);
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(flag3);
		}
		base.GetTexture(1).SetAlpha(flag ? 1f : 0.4f);
		UUISprite sprite = base.GetSprite(3);
		if (sprite != null)
		{
			sprite.SetUIActive(!flag);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(!flag2);
		}
		UUIItem item3 = base.GetItem(6);
		if (item3 != null)
		{
			item3.SetUIActive(flag2);
		}
		UUISprite sprite2 = base.GetSprite(4);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(flag2 && !flag3);
		}
		if (this.IsSelectOnCb != null)
		{
			this.SetSelected(this.IsSelectOnCb(configId), false);
		}
	}

	// Token: 0x06006B8E RID: 27534 RVA: 0x001C2C64 File Offset: 0x001C0E64
	private void SetSelected(bool bSelectOn, bool bFireEvent = false)
	{
		base.GetExtendToggle(0).SetToggleState(bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
	}

	// Token: 0x06006B8F RID: 27535 RVA: 0x001C2C7D File Offset: 0x001C0E7D
	private void OnToggleStateChange(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked && this.OnToggleStateChangeFunction != null)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.OnToggleStateChangeFunction(this.ConfigId);
		}
	}

	// Token: 0x04003325 RID: 13093
	private int ConfigId = -1;

	// Token: 0x04003326 RID: 13094
	public Action<int> ClickCallBack;

	// Token: 0x04003327 RID: 13095
	public Func<int, bool> IsSelectOnCb;

	// Token: 0x04003328 RID: 13096
	public Action<int> OnToggleStateChangeFunction;
}

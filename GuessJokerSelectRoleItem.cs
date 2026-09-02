using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001133 RID: 4403
public class GuessJokerSelectRoleItem : GridProxyAbstract<int>
{
	// Token: 0x0600734A RID: 29514 RVA: 0x001E2A44 File Offset: 0x001E0C44
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x17000955 RID: 2389
	// (get) Token: 0x0600734B RID: 29515 RVA: 0x001E2AF0 File Offset: 0x001E0CF0
	public int Level
	{
		get
		{
			if (this.LevelId == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJokerSelectRoleItem获取LevelId为0", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return this.LevelId;
		}
	}

	// Token: 0x0600734C RID: 29516 RVA: 0x001E2B2C File Offset: 0x001E0D2C
	public override void Refresh(int levelId, bool isSelected, int gridIndex)
	{
		this.LevelId = levelId;
		int aiRole = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId).Value.AiRole;
		base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(aiRole).Value.RoleHeadIconCircle, base.GetTexture(1), aiRole, null, null);
		SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		if (activityData.GetGuessJokerGameData(levelId) == null)
		{
			return;
		}
		this.RefreshRedDot();
	}

	// Token: 0x0600734D RID: 29517 RVA: 0x001E2BB4 File Offset: 0x001E0DB4
	public void RefreshRedDot()
	{
		SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		IGuessJokerLevelInfo guessJokerGameData = activityData.GetGuessJokerGameData(this.LevelId);
		if (guessJokerGameData == null)
		{
			return;
		}
		bool unlock = guessJokerGameData.Unlock;
		bool firstPass = guessJokerGameData.FirstPass;
		bool rewardGet = guessJokerGameData.RewardGet;
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.GuessJokerUnlockLevelClicked, null) ?? new HashSet<int>();
		bool uiactive = (unlock && !firstPass && !hashSet.Contains(this.LevelId)) || (firstPass && !rewardGet);
		base.GetItem(2).SetUIActive(uiactive);
		base.GetSprite(4).SetUIActive(firstPass && rewardGet);
		base.GetSprite(3).SetUIActive(!unlock);
	}

	// Token: 0x0600734E RID: 29518 RVA: 0x001E2C60 File Offset: 0x001E0E60
	[NullableContext(1)]
	public void BindClickCallBack(Action<GuessJokerSelectRoleItem> clickCallBack)
	{
		this.ClickCallBack = clickCallBack;
	}

	// Token: 0x0600734F RID: 29519 RVA: 0x001E2C69 File Offset: 0x001E0E69
	private void OnClickToggle(EToggleState state)
	{
		Action<GuessJokerSelectRoleItem> clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this);
	}

	// Token: 0x06007350 RID: 29520 RVA: 0x001E2C7C File Offset: 0x001E0E7C
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06007351 RID: 29521 RVA: 0x001E2C8E File Offset: 0x001E0E8E
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06007352 RID: 29522 RVA: 0x001E2CA0 File Offset: 0x001E0EA0
	[NullableContext(2)]
	public UUIItem GuideGetToggleItem()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return null;
		}
		return extendToggle.RootUIComp.Get();
	}

	// Token: 0x040037AE RID: 14254
	private int LevelId;

	// Token: 0x040037AF RID: 14255
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<GuessJokerSelectRoleItem> ClickCallBack;
}

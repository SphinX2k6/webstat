using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001805 RID: 6149
internal class SelectTargetItem : GridProxyAbstract<int>
{
	// Token: 0x0600AEC5 RID: 44741 RVA: 0x002E8DC0 File Offset: 0x002E6FC0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0600AEC6 RID: 44742 RVA: 0x002E8E40 File Offset: 0x002E7040
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.FetterId = data;
		int[] fetterGroupMonsterIdArray = ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(this.FetterId);
		int monsterFindCountByMonsterIdArrayWithoutCost = ModelBase<PhantomBattleModel>.Instance.GetMonsterFindCountByMonsterIdArrayWithoutCost4(fetterGroupMonsterIdArray);
		bool flag = this.FetterId == ModelBase<CalabashModel>.Instance.DirectionalFusionTargetFetterGroup;
		if (monsterFindCountByMonsterIdArrayWithoutCost <= 0)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
		}
		else
		{
			base.GetExtendToggle(1).SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, true, false, false);
		}
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.FetterId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), fetterGroupById.FetterGroupName, Array.Empty<object>());
		base.SetTextureByPath(fetterGroupById.FetterElementPath, base.GetTexture(2), null, null);
	}

	// Token: 0x0600AEC7 RID: 44743 RVA: 0x002E8EFC File Offset: 0x002E70FC
	private void OnClickToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.FetterId, base.GetExtendToggle(1));
			return;
		}
		else
		{
			Action<int, UUIExtendToggle> onClickToggleCallBack2 = this.OnClickToggleCallBack;
			if (onClickToggleCallBack2 == null)
			{
				return;
			}
			onClickToggleCallBack2(0, base.GetExtendToggle(1));
			return;
		}
	}

	// Token: 0x040052F1 RID: 21233
	private int FetterId;

	// Token: 0x040052F2 RID: 21234
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, UUIExtendToggle> OnClickToggleCallBack;

	// Token: 0x02007B79 RID: 31609
	private enum ESelectTargetItem
	{
		// Token: 0x0402A33C RID: 172860
		NameText,
		// Token: 0x0402A33D RID: 172861
		Toggle,
		// Token: 0x0402A33E RID: 172862
		Texture
	}
}

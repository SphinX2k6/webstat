using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020025C0 RID: 9664
[Nullable(new byte[]
{
	0,
	1
})]
public class FightPhotoConditionItem : GridProxyAbstract<FightPhotoConditionData>
{
	// Token: 0x06012E3B RID: 77371 RVA: 0x00539C1C File Offset: 0x00537E1C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x06012E3C RID: 77372 RVA: 0x00539C76 File Offset: 0x00537E76
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnChangeFightPhotoOption, new Action(this.OnChangeFightPhotoOption));
	}

	// Token: 0x06012E3D RID: 77373 RVA: 0x00539C94 File Offset: 0x00537E94
	[NullableContext(1)]
	public override void Refresh(FightPhotoConditionData data, bool isSelected, int gridIndex)
	{
		this.ConditionType = data.ConditionType;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Text, Array.Empty<object>());
		this.RefreshConditionStatus();
	}

	// Token: 0x06012E3E RID: 77374 RVA: 0x00539CC4 File Offset: 0x00537EC4
	public void RefreshConditionStatus()
	{
		FightPhotoModel instance = ModelBase<FightPhotoModel>.Instance;
		TakePicturesWithTimeScaleChildQuestNode currentBtNode = ControllerBase<PhotographController>.Instance.CurrentBtNode;
		bool uiactive;
		if (this.ConditionType == EFightPhotoConditionType.CameraCondition)
		{
			uiactive = instance.CheckCameraCondition((currentBtNode != null) ? currentBtNode.CameraCondition : null);
		}
		else
		{
			uiactive = (instance.CheckRoleInCamera((currentBtNode != null) ? currentBtNode.PhotographCondition : null) && instance.CheckPhotographCondition((currentBtNode != null) ? currentBtNode.PhotographCondition : null));
		}
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetUIActive(uiactive);
		}
		UUITexture texture = base.GetTexture(2);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(uiactive);
	}

	// Token: 0x06012E3F RID: 77375 RVA: 0x00539D51 File Offset: 0x00537F51
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeFightPhotoOption, new Action(this.OnChangeFightPhotoOption));
	}

	// Token: 0x06012E40 RID: 77376 RVA: 0x00539D6F File Offset: 0x00537F6F
	private void OnChangeFightPhotoOption()
	{
		this.RefreshConditionStatus();
	}

	// Token: 0x040093A2 RID: 37794
	private EFightPhotoConditionType ConditionType;

	// Token: 0x0200891E RID: 35102
	private enum EComponents
	{
		// Token: 0x0402E450 RID: 189520
		SpriteFinish,
		// Token: 0x0402E451 RID: 189521
		TextDescription,
		// Token: 0x0402E452 RID: 189522
		TextureFinishBg
	}
}

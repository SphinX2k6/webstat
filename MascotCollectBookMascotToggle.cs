using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F75 RID: 8053
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MascotCollectBookMascotToggle : GridProxyAbstract<HonamiStoryMascotData>
{
	// Token: 0x0600F14E RID: 61774 RVA: 0x0041F300 File Offset: 0x0041D500
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggle))
		};
	}

	// Token: 0x0600F14F RID: 61775 RVA: 0x0041F37D File Offset: 0x0041D57D
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600F150 RID: 61776 RVA: 0x0041F39B File Offset: 0x0041D59B
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600F151 RID: 61777 RVA: 0x0041F3B9 File Offset: 0x0041D5B9
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "Bozai_Unlock")
		{
			this.RefreshItem();
		}
	}

	// Token: 0x0600F152 RID: 61778 RVA: 0x0041F3CE File Offset: 0x0041D5CE
	protected override void OnBeforeCreateImplement()
	{
		this.LevelPlaySequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.LevelPlaySequence);
	}

	// Token: 0x1700126B RID: 4715
	// (get) Token: 0x0600F153 RID: 61779 RVA: 0x0041F3E8 File Offset: 0x0041D5E8
	public HonamiStoryMascotData Data
	{
		get
		{
			return this.MascotData;
		}
	}

	// Token: 0x0600F154 RID: 61780 RVA: 0x0041F3F0 File Offset: 0x0041D5F0
	public override void Refresh(HonamiStoryMascotData mascotData, bool isSelected, int gridIndex)
	{
		this.MascotData = mascotData;
		bool flag = (LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryMascotUnlockSet, new HashSet<int>()) ?? new HashSet<int>()).Contains(mascotData.Id);
		if (mascotData.State != EHonamiStoryCollectState.Finished || !flag)
		{
			this.RefreshItem();
			return;
		}
		UiBehaviorLevelSequence levelPlaySequence = this.LevelPlaySequence;
		if (levelPlaySequence == null)
		{
			return;
		}
		levelPlaySequence.PlaySequence("PnlHead_Unlock", false, null);
	}

	// Token: 0x0600F155 RID: 61781 RVA: 0x0041F45C File Offset: 0x0041D65C
	private void RefreshItem()
	{
		base.GetTexture(2).SetUIActive(this.MascotData.State == EHonamiStoryCollectState.Finished);
		string path = this.MascotData.Config.Value.TogglePicture;
		if (this.MascotData.State == EHonamiStoryCollectState.Unfinished)
		{
			path = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity28/HonamiStory/HonamiStoryHead/T_HonamiStoryHeadBEmpty.T_HonamiStoryHeadBEmpty";
		}
		base.SetTextureByPath(path, base.GetTexture(1), null, null);
	}

	// Token: 0x0600F156 RID: 61782 RVA: 0x0041F4CA File Offset: 0x0041D6CA
	public void BindMascotToggleClick(Action<MascotCollectBookMascotToggle> callback)
	{
		this.OnMascotToggleClick = callback;
	}

	// Token: 0x0600F157 RID: 61783 RVA: 0x0041F4D3 File Offset: 0x0041D6D3
	private void OnToggle(EToggleState toggleState)
	{
		Action<MascotCollectBookMascotToggle> onMascotToggleClick = this.OnMascotToggleClick;
		if (onMascotToggleClick == null)
		{
			return;
		}
		onMascotToggleClick(this);
	}

	// Token: 0x0600F158 RID: 61784 RVA: 0x0041F4E6 File Offset: 0x0041D6E6
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600F159 RID: 61785 RVA: 0x0041F4F8 File Offset: 0x0041D6F8
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x040073E0 RID: 29664
	private HonamiStoryMascotData MascotData;

	// Token: 0x040073E1 RID: 29665
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<MascotCollectBookMascotToggle> OnMascotToggleClick;

	// Token: 0x040073E2 RID: 29666
	[Nullable(2)]
	private UiBehaviorLevelSequence LevelPlaySequence;

	// Token: 0x02008314 RID: 33556
	[NullableContext(0)]
	private enum EMascotCollectBookMascotToggleComponent
	{
		// Token: 0x0402C71C RID: 182044
		Toggle,
		// Token: 0x0402C71D RID: 182045
		PictureTexture,
		// Token: 0x0402C71E RID: 182046
		RewardTexture
	}
}

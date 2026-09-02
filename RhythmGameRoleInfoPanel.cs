using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001145 RID: 4421
public class RhythmGameRoleInfoPanel : UiPanelBase
{
	// Token: 0x0600746A RID: 29802 RVA: 0x001E7CD8 File Offset: 0x001E5ED8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600746B RID: 29803 RVA: 0x001E7D34 File Offset: 0x001E5F34
	protected override void OnBeforeShow()
	{
		int? num = this.OpenParam as int?;
		if (num == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.BB, "RhythmGameRoleInfoPanel OpenParam is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.roleId = num.Value;
		RhythmRole? rhythmRoleById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmRoleById(this.roleId);
		if (rhythmRoleById == null)
		{
			return;
		}
		this.RoleSkillAudio = rhythmRoleById.Value.RoleSkillMusic;
		base.SetTextureShowUntilLoaded(rhythmRoleById.Value.RoleHeadTexture2, base.GetTexture(0), null);
		base.GetItem(1).SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rhythmRoleById.Value.RoleSkillText, Array.Empty<object>());
	}

	// Token: 0x0600746C RID: 29804 RVA: 0x001E7E07 File Offset: 0x001E6007
	protected override void OnAfterShow()
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(this.roleId != 0);
	}

	// Token: 0x0600746D RID: 29805 RVA: 0x001E7E24 File Offset: 0x001E6024
	public void ShowRoleFeverInfo()
	{
		base.GetItem(1).SetUIActive(true);
		if (this.RoleSkillAudio != "")
		{
			ControllerBase<RhythmGameController>.Instance.PlayRoleFeverAudio(this.RoleSkillAudio);
		}
		TimerSystemInstance rhythmGameTimerSystem = ControllerBase<RhythmGameController>.Instance.RhythmGameTimerSystem;
		if (rhythmGameTimerSystem == null)
		{
			return;
		}
		rhythmGameTimerSystem.Delay(delegate(float _)
		{
			base.GetItem(1).SetUIActive(false);
		}, (float)this.RhythmGameRoleFeverAudioDelayTime, null, null, true, 1f);
	}

	// Token: 0x04003831 RID: 14385
	private readonly int RhythmGameRoleFeverAudioDelayTime = 4000;

	// Token: 0x04003832 RID: 14386
	[Nullable(1)]
	private string RoleSkillAudio = "";

	// Token: 0x04003833 RID: 14387
	private int roleId;

	// Token: 0x020074D2 RID: 29906
	private enum EComponent
	{
		// Token: 0x04028542 RID: 165186
		IconRole,
		// Token: 0x04028543 RID: 165187
		InfoItem,
		// Token: 0x04028544 RID: 165188
		RoleSkillText
	}
}

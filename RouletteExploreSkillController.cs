using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.QuestMultiLine;
using Cysharp.Threading.Tasks;

// Token: 0x0200292C RID: 10540
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RouletteExploreSkillController : ControllerBase<RouletteExploreSkillController>
{
	// Token: 0x06014EDB RID: 85723 RVA: 0x005CADA0 File Offset: 0x005C8FA0
	public void UseRouletteExploreId(ERouletteExploreId exploreId)
	{
		if (!ModelBase<RouletteModel>.Instance.GetCurrentExploreRouletteListData().IsExploreSkillIdAllowEquip((int)exploreId))
		{
			return;
		}
		SVisionData visionData = PhantomUtil.GetVisionData((int)exploreId);
		if (visionData == null)
		{
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || getCurrentEntity.Entity == null)
		{
			return;
		}
		if (this.UseExploreSkillId(getCurrentEntity.Id, visionData.技能ID))
		{
			ModelBase<RouletteModel>.Instance.TrySendExploreToolGeneralUseLogData((int)exploreId, 0, 0);
		}
	}

	// Token: 0x06014EDC RID: 85724 RVA: 0x005CAE0C File Offset: 0x005C900C
	public bool UseExploreSkillId(int entityId, int skillId)
	{
		Action<int, int> action;
		if (this.RouletteExploreSkillUseWayMap.TryGetValue((ERouletteSkillId)skillId, out action))
		{
			action(entityId, skillId);
			return true;
		}
		return false;
	}

	// Token: 0x06014EDD RID: 85725 RVA: 0x005CAE34 File Offset: 0x005C9034
	private static void OnUseEquipItem(int entityId, int skillId)
	{
		ControllerBase<RouletteController>.Instance.OnUseEquipItem();
	}

	// Token: 0x06014EDE RID: 85726 RVA: 0x005CAE40 File Offset: 0x005C9040
	private static void OpenEmptyTips(int entityId, int skillId)
	{
		ControllerBase<RouletteController>.Instance.OpenEmptyTips();
	}

	// Token: 0x06014EDF RID: 85727 RVA: 0x005CAE4C File Offset: 0x005C904C
	private static void UseMapExploreTool(int entityId, int skillId)
	{
		ControllerBase<MapExploreToolController>.Instance.CheckUseMapExploreTool(entityId, skillId);
	}

	// Token: 0x06014EE0 RID: 85728 RVA: 0x005CAE5A File Offset: 0x005C905A
	private static void OpenAdviceCreateView(int entityId, int skillId)
	{
		ControllerBase<AdviceController>.Instance.OpenAdviceCreateView();
	}

	// Token: 0x06014EE1 RID: 85729 RVA: 0x005CAE66 File Offset: 0x005C9066
	private static void PhotographFastScreenShot(int entityId, int skillId)
	{
		ControllerBase<PhotographController>.Instance.PhotographFastScreenShot(ECameraCaptureType.NormalCamera);
	}

	// Token: 0x06014EE2 RID: 85730 RVA: 0x005CAE73 File Offset: 0x005C9073
	private static void OpenFightPhotograph(int entityId, int skillId)
	{
		ControllerBase<PhotographController>.Instance.TryOpenPhotograph(ECameraCaptureType.FightPhotographCamera);
	}

	// Token: 0x06014EE3 RID: 85731 RVA: 0x005CAE81 File Offset: 0x005C9081
	private static void EnterMotorAutoPilot(int entityId, int skillId)
	{
		ControllerBase<AutoPilotController>.Instance.EnterAutoPilot().Forget<bool>();
	}

	// Token: 0x06014EE4 RID: 85732 RVA: 0x005CAE92 File Offset: 0x005C9092
	private static void SummonMotorAndEnterAutoPilot(int entityId, int skillId)
	{
		ControllerBase<AutoPilotController>.Instance.SummonMotorAndEnterAutoPilot();
	}

	// Token: 0x06014EE5 RID: 85733 RVA: 0x005CAE9E File Offset: 0x005C909E
	private static void OpenMotorMusicPlayer(int entityId, int skillId)
	{
		ControllerBase<MotorcycleMusicPlayerController>.Instance.OpenMusicPlayerView();
	}

	// Token: 0x06014EE6 RID: 85734 RVA: 0x005CAEAA File Offset: 0x005C90AA
	private static void OpenPhantomSummonView(int entityId, int skillId)
	{
		ControllerBase<PhantomInteractController>.Instance.OpenPhantomVisionSummonView(entityId, skillId);
	}

	// Token: 0x06014EE7 RID: 85735 RVA: 0x005CAEB8 File Offset: 0x005C90B8
	private static void OpenMotorTechTreeSwitchView(int entityId, int skillId)
	{
		ControllerBase<MotorcycleDevelopController>.Instance.OpenMotorTechTreeSwitchView();
	}

	// Token: 0x06014EE8 RID: 85736 RVA: 0x005CAEC4 File Offset: 0x005C90C4
	private static void OpenQuestMultiLineView(int entityId, int skillId)
	{
		ControllerBase<QuestMultiLineController>.Instance.OpenQuestMultiLineView(0, false, false);
	}

	// Token: 0x06014EE9 RID: 85737 RVA: 0x005CAED4 File Offset: 0x005C90D4
	public RouletteExploreSkillController()
	{
		Dictionary<ERouletteSkillId, Action<int, int>> dictionary = new Dictionary<ERouletteSkillId, Action<int, int>>();
		ERouletteSkillId key = ERouletteSkillId.道具装配;
		Action<int, int> value;
		if ((value = RouletteExploreSkillController.<>O.<0>__OnUseEquipItem) == null)
		{
			value = (RouletteExploreSkillController.<>O.<0>__OnUseEquipItem = new Action<int, int>(RouletteExploreSkillController.OnUseEquipItem));
		}
		dictionary.Add(key, value);
		ERouletteSkillId key2 = ERouletteSkillId.道具空置;
		Action<int, int> value2;
		if ((value2 = RouletteExploreSkillController.<>O.<1>__OpenEmptyTips) == null)
		{
			value2 = (RouletteExploreSkillController.<>O.<1>__OpenEmptyTips = new Action<int, int>(RouletteExploreSkillController.OpenEmptyTips));
		}
		dictionary.Add(key2, value2);
		ERouletteSkillId key3 = ERouletteSkillId.临时传送;
		Action<int, int> value3;
		if ((value3 = RouletteExploreSkillController.<>O.<2>__UseMapExploreTool) == null)
		{
			value3 = (RouletteExploreSkillController.<>O.<2>__UseMapExploreTool = new Action<int, int>(RouletteExploreSkillController.UseMapExploreTool));
		}
		dictionary.Add(key3, value3);
		ERouletteSkillId key4 = ERouletteSkillId.声匣探测;
		Action<int, int> value4;
		if ((value4 = RouletteExploreSkillController.<>O.<2>__UseMapExploreTool) == null)
		{
			value4 = (RouletteExploreSkillController.<>O.<2>__UseMapExploreTool = new Action<int, int>(RouletteExploreSkillController.UseMapExploreTool));
		}
		dictionary.Add(key4, value4);
		ERouletteSkillId key5 = ERouletteSkillId.物资探测;
		Action<int, int> value5;
		if ((value5 = RouletteExploreSkillController.<>O.<2>__UseMapExploreTool) == null)
		{
			value5 = (RouletteExploreSkillController.<>O.<2>__UseMapExploreTool = new Action<int, int>(RouletteExploreSkillController.UseMapExploreTool));
		}
		dictionary.Add(key5, value5);
		ERouletteSkillId key6 = ERouletteSkillId.溯言刻录;
		Action<int, int> value6;
		if ((value6 = RouletteExploreSkillController.<>O.<3>__OpenAdviceCreateView) == null)
		{
			value6 = (RouletteExploreSkillController.<>O.<3>__OpenAdviceCreateView = new Action<int, int>(RouletteExploreSkillController.OpenAdviceCreateView));
		}
		dictionary.Add(key6, value6);
		ERouletteSkillId key7 = ERouletteSkillId.影像速采;
		Action<int, int> value7;
		if ((value7 = RouletteExploreSkillController.<>O.<4>__PhotographFastScreenShot) == null)
		{
			value7 = (RouletteExploreSkillController.<>O.<4>__PhotographFastScreenShot = new Action<int, int>(RouletteExploreSkillController.PhotographFastScreenShot));
		}
		dictionary.Add(key7, value7);
		ERouletteSkillId key8 = ERouletteSkillId.时停相机;
		Action<int, int> value8;
		if ((value8 = RouletteExploreSkillController.<>O.<5>__OpenFightPhotograph) == null)
		{
			value8 = (RouletteExploreSkillController.<>O.<5>__OpenFightPhotograph = new Action<int, int>(RouletteExploreSkillController.OpenFightPhotograph));
		}
		dictionary.Add(key8, value8);
		ERouletteSkillId key9 = ERouletteSkillId.摩托自动巡航;
		Action<int, int> value9;
		if ((value9 = RouletteExploreSkillController.<>O.<6>__EnterMotorAutoPilot) == null)
		{
			value9 = (RouletteExploreSkillController.<>O.<6>__EnterMotorAutoPilot = new Action<int, int>(RouletteExploreSkillController.EnterMotorAutoPilot));
		}
		dictionary.Add(key9, value9);
		ERouletteSkillId key10 = ERouletteSkillId.摩托车电台;
		Action<int, int> value10;
		if ((value10 = RouletteExploreSkillController.<>O.<7>__OpenMotorMusicPlayer) == null)
		{
			value10 = (RouletteExploreSkillController.<>O.<7>__OpenMotorMusicPlayer = new Action<int, int>(RouletteExploreSkillController.OpenMotorMusicPlayer));
		}
		dictionary.Add(key10, value10);
		ERouletteSkillId key11 = ERouletteSkillId.摩托上车接自动巡航;
		Action<int, int> value11;
		if ((value11 = RouletteExploreSkillController.<>O.<8>__SummonMotorAndEnterAutoPilot) == null)
		{
			value11 = (RouletteExploreSkillController.<>O.<8>__SummonMotorAndEnterAutoPilot = new Action<int, int>(RouletteExploreSkillController.SummonMotorAndEnterAutoPilot));
		}
		dictionary.Add(key11, value11);
		ERouletteSkillId key12 = ERouletteSkillId.声骸显像界面入口;
		Action<int, int> value12;
		if ((value12 = RouletteExploreSkillController.<>O.<9>__OpenPhantomSummonView) == null)
		{
			value12 = (RouletteExploreSkillController.<>O.<9>__OpenPhantomSummonView = new Action<int, int>(RouletteExploreSkillController.OpenPhantomSummonView));
		}
		dictionary.Add(key12, value12);
		ERouletteSkillId key13 = ERouletteSkillId.摩托车声骸显像界面入口;
		Action<int, int> value13;
		if ((value13 = RouletteExploreSkillController.<>O.<9>__OpenPhantomSummonView) == null)
		{
			value13 = (RouletteExploreSkillController.<>O.<9>__OpenPhantomSummonView = new Action<int, int>(RouletteExploreSkillController.OpenPhantomSummonView));
		}
		dictionary.Add(key13, value13);
		ERouletteSkillId key14 = ERouletteSkillId.摩托车切换科技树;
		Action<int, int> value14;
		if ((value14 = RouletteExploreSkillController.<>O.<10>__OpenMotorTechTreeSwitchView) == null)
		{
			value14 = (RouletteExploreSkillController.<>O.<10>__OpenMotorTechTreeSwitchView = new Action<int, int>(RouletteExploreSkillController.OpenMotorTechTreeSwitchView));
		}
		dictionary.Add(key14, value14);
		ERouletteSkillId key15 = ERouletteSkillId.主线任务分线界面;
		Action<int, int> value15;
		if ((value15 = RouletteExploreSkillController.<>O.<11>__OpenQuestMultiLineView) == null)
		{
			value15 = (RouletteExploreSkillController.<>O.<11>__OpenQuestMultiLineView = new Action<int, int>(RouletteExploreSkillController.OpenQuestMultiLineView));
		}
		dictionary.Add(key15, value15);
		this.RouletteExploreSkillUseWayMap = dictionary;
		base..ctor();
	}

	// Token: 0x0400A134 RID: 41268
	private readonly Dictionary<ERouletteSkillId, Action<int, int>> RouletteExploreSkillUseWayMap;

	// Token: 0x02008C5A RID: 35930
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402F43E RID: 193598
		[Nullable(0)]
		public static Action<int, int> <0>__OnUseEquipItem;

		// Token: 0x0402F43F RID: 193599
		[Nullable(0)]
		public static Action<int, int> <1>__OpenEmptyTips;

		// Token: 0x0402F440 RID: 193600
		[Nullable(0)]
		public static Action<int, int> <2>__UseMapExploreTool;

		// Token: 0x0402F441 RID: 193601
		[Nullable(0)]
		public static Action<int, int> <3>__OpenAdviceCreateView;

		// Token: 0x0402F442 RID: 193602
		[Nullable(0)]
		public static Action<int, int> <4>__PhotographFastScreenShot;

		// Token: 0x0402F443 RID: 193603
		[Nullable(0)]
		public static Action<int, int> <5>__OpenFightPhotograph;

		// Token: 0x0402F444 RID: 193604
		[Nullable(0)]
		public static Action<int, int> <6>__EnterMotorAutoPilot;

		// Token: 0x0402F445 RID: 193605
		[Nullable(0)]
		public static Action<int, int> <7>__OpenMotorMusicPlayer;

		// Token: 0x0402F446 RID: 193606
		[Nullable(0)]
		public static Action<int, int> <8>__SummonMotorAndEnterAutoPilot;

		// Token: 0x0402F447 RID: 193607
		[Nullable(0)]
		public static Action<int, int> <9>__OpenPhantomSummonView;

		// Token: 0x0402F448 RID: 193608
		[Nullable(0)]
		public static Action<int, int> <10>__OpenMotorTechTreeSwitchView;

		// Token: 0x0402F449 RID: 193609
		[Nullable(0)]
		public static Action<int, int> <11>__OpenQuestMultiLineView;
	}
}

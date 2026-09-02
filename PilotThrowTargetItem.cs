using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGamePlay.Common;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020025EE RID: 9710
[NullableContext(1)]
[Nullable(0)]
public class PilotThrowTargetItem : CommonMarkItem
{
	// Token: 0x06013066 RID: 77926 RVA: 0x00545DD8 File Offset: 0x00543FD8
	public PilotThrowTargetItem(IPilotThrowTarget config)
	{
		FVectorDouble fvectorDouble = Vector.Create((double)config.Position.X.GetValueOrDefault(), (double)config.Position.Y.GetValueOrDefault(), (double)config.Position.Z.GetValueOrDefault()).ToUeVector(false);
		base..ctor(fvectorDouble, null);
		this.AimTarget.Set(this.TargetPosition.X, this.TargetPosition.Y, this.TargetPosition.Z);
		this.IsMainStoryTarget = (config.VisualType == EPilotThrowPointVisualType.MainStory);
		this.IsPlantFlagTarget = (config.VisualType == EPilotThrowPointVisualType.PlantFlag);
	}

	// Token: 0x06013067 RID: 77927 RVA: 0x00545E98 File Offset: 0x00544098
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
	}

	// Token: 0x06013068 RID: 77928 RVA: 0x00545F78 File Offset: 0x00544178
	protected override void OnStart()
	{
		Rotator rootActorRotation = this.RootActorRotation;
		FRotator frotator = this.RootActor.K2_GetActorRotation();
		rootActorRotation.FromUeRotator(frotator);
		this.LockContent = base.GetItem(3);
		UUIItem lockContent = this.LockContent;
		if (lockContent != null)
		{
			lockContent.SetUIActive(false);
		}
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetAsFirstHierarchy();
		}
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(!this.IsMainStoryTarget);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(this.IsMainStoryTarget);
		}
		UUIItem item3 = base.GetItem(4);
		if (item3 != null)
		{
			item3.SetUIActive(this.IsMainStoryTarget);
		}
		UUIItem item4 = base.GetItem(6);
		if (item4 != null)
		{
			item4.SetUIActive(!this.IsMainStoryTarget);
		}
		UUIItem item5 = base.GetItem(7);
		if (item5 != null)
		{
			item5.SetUIActive(this.IsMainStoryTarget);
		}
		if (this.IsPlantFlagTarget)
		{
			UUIItem item6 = base.GetItem(5);
			if (item6 != null)
			{
				item6.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "FlagChallenge_BossWarning", Array.Empty<object>());
		}
		else
		{
			UUIItem item7 = base.GetItem(5);
			if (item7 != null)
			{
				item7.SetUIActive(false);
			}
		}
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		UUIItem rootItem2 = this.RootItem;
		if (rootItem2 != null)
		{
			rootItem2.SetUIRelativeLocation(UKismetMathLibrary.Conv_VectorDoubleToVector(this.TargetPosition));
		}
		this.UpdateScale();
		UUIItem item8 = base.GetItem(0);
		if (item8 != null)
		{
			item8.SetUIActive(false);
		}
		this.InitEffect();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.PilotThrow;
		ELogAuthor author = ELogAuthor.CH;
		string message = "[PilotThrowTargetItem.OnStart] 初始化目标点";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", ModelBase<PilotThrowModel>.Instance.GetCurrentInteractHookPoint());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06013069 RID: 77929 RVA: 0x00546154 File Offset: 0x00544354
	private void InitEffect()
	{
		if (PilotThrowTargetItem.LineTrace == null)
		{
			PilotThrowTargetItem.InitLineTraceInfo();
		}
		Singleton<TraceElementCommon>.Instance.SetStartLocation(PilotThrowTargetItem.LineTrace, this.TargetPosition);
		FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, -6000.0);
		FVectorDouble fvectorDouble2 = this.TargetPosition + fvectorDouble;
		Singleton<TraceElementCommon>.Instance.SetEndLocation(PilotThrowTargetItem.LineTrace, fvectorDouble2);
		if (Singleton<TraceElementCommon>.Instance.LineTrace(PilotThrowTargetItem.LineTrace, "PilotThrowTargetItem"))
		{
			Vector vector = Vector.Create();
			Singleton<TraceElementCommon>.Instance.GetHitLocation(PilotThrowTargetItem.LineTrace.HitResult, 0, vector);
			FTransformDouble value = new FTransformDouble(ref Singleton<MathUtils>.Instance.DefaultTransform);
			fvectorDouble = vector.ToUeVector(false);
			value.SetLocation(fvectorDouble);
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(value);
			this.EffectHandle = new int?(instance.SpawnEffect(world, ftransformDouble, "/Game/Aki/Effect/EffectGroup/BigWorld/LHL/DA_Fx_Group_Sl2_LHL_Guangzhu_60M.DA_Fx_Group_Sl2_LHL_Guangzhu_60M", "PilotThrowTargetItem", null, EEffectType.Scene, null, null, null, false, false));
		}
	}

	// Token: 0x0601306A RID: 77930 RVA: 0x00546254 File Offset: 0x00544454
	private static void InitLineTraceInfo()
	{
		PilotThrowTargetItem.LineTrace = new UTraceLineElement();
		PilotThrowTargetItem.LineTrace.WorldContextObject = GlobalData.World;
		PilotThrowTargetItem.LineTrace.bIsSingle = false;
		PilotThrowTargetItem.LineTrace.bIgnoreSelf = true;
		PilotThrowTargetItem.LineTrace.bIsProfile = true;
		PilotThrowTargetItem.LineTrace.DrawTime = 0.5f;
		Singleton<TraceElementCommon>.Instance.SetTraceColor(PilotThrowTargetItem.LineTrace, PilotThrowTargetItem.LineTraceColor);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(PilotThrowTargetItem.LineTrace, new FLinearColor(0f, 1f, 0f, 1f));
	}

	// Token: 0x0601306B RID: 77931 RVA: 0x005462E6 File Offset: 0x005444E6
	private void OnSequenceClose(string sequenceName)
	{
		if (!(sequenceName == "Lock_Out_new"))
		{
			if (sequenceName == "Close")
			{
				this.CloseMeAsync().Forget<bool>();
			}
			return;
		}
		UUIItem lockContent = this.LockContent;
		if (lockContent == null)
		{
			return;
		}
		lockContent.SetUIActive(false);
	}

	// Token: 0x0601306C RID: 77932 RVA: 0x00546320 File Offset: 0x00544520
	public void Close()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		}
		int? effectHandle = this.EffectHandle;
		if (effectHandle != null && effectHandle.GetValueOrDefault() != 0)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle.Value, "PilotThrowTargetItem", false, null);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.PilotThrow;
		ELogAuthor author = ELogAuthor.CH;
		string message = "[PilotThrowTargetItem.Close] 关闭目标点";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", ModelBase<PilotThrowModel>.Instance.GetCurrentInteractHookPoint());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601306D RID: 77933 RVA: 0x005463C4 File Offset: 0x005445C4
	public override void OnTick(float delta)
	{
		this.UpdateRotation();
		bool flag = ModelBase<PilotThrowModel>.Instance.IsInProjectileSplineLastPointRange(this.AimTarget);
		if (flag != this.LastInTargetRange)
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.StopPlayingSequence(false, true);
			}
			if (flag)
			{
				UUIItem lockContent = this.LockContent;
				if (lockContent != null)
				{
					lockContent.SetUIActive(flag);
				}
				ModelBase<PilotThrowModel>.Instance.CurrentInRangePoint = Vector.Create(this.TargetPosition.X, this.TargetPosition.Y, this.TargetPosition.Z);
			}
			else
			{
				ModelBase<PilotThrowModel>.Instance.CurrentInRangePoint = null;
			}
			LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 != null)
			{
				sequencePlayer2.PlayLevelSequenceByName(flag ? "Lock_In_new" : "Lock_Out_new", false, null, false);
			}
			this.LastInTargetRange = flag;
			Action<bool> onTargetInOutRange = this.OnTargetInOutRange;
			if (onTargetInOutRange == null)
			{
				return;
			}
			onTargetInOutRange(flag);
		}
	}

	// Token: 0x0601306E RID: 77934 RVA: 0x0054649C File Offset: 0x0054469C
	public void UpdateRotation()
	{
		Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
		this.RootActorRotation.Yaw = cameraRotator.Yaw + 90f;
		this.RootActorRotation.Roll = cameraRotator.Pitch - 90f;
		this.RootActorRotation.Pitch = 0f;
		UUIItem rootItem = this.RootItem;
		FRotator frotator = this.RootActorRotation.ToUeRotator();
		rootItem.SetUIRelativeRotation(frotator);
	}

	// Token: 0x0601306F RID: 77935 RVA: 0x00546510 File Offset: 0x00544710
	public void UpdateScale()
	{
		float inTime = (float)Vector.Dist(Vector.Create(ControllerBase<CameraController>.Instance.MainModel.CameraLocation), this.AimTarget) / 100f;
		float floatValue = ModelBase<PilotThrowModel>.Instance.Setting.缩放曲线.GetFloatValue(inTime);
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetRelativeScale3D(new FVector(floatValue, floatValue, floatValue));
	}

	// Token: 0x04009467 RID: 37991
	[Nullable(2)]
	private UUIItem LockContent;

	// Token: 0x04009468 RID: 37992
	protected Rotator RootActorRotation = Rotator.Create();

	// Token: 0x04009469 RID: 37993
	private readonly Vector AimTarget = Vector.Create();

	// Token: 0x0400946A RID: 37994
	private readonly bool IsMainStoryTarget;

	// Token: 0x0400946B RID: 37995
	private readonly bool IsPlantFlagTarget;

	// Token: 0x0400946C RID: 37996
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x0400946D RID: 37997
	[Nullable(2)]
	public Action<bool> OnTargetInOutRange;

	// Token: 0x0400946E RID: 37998
	[Nullable(2)]
	[StaticVariableRuleIgnore]
	private static UTraceLineElement LineTrace = null;

	// Token: 0x0400946F RID: 37999
	private int? EffectHandle;

	// Token: 0x04009470 RID: 38000
	private bool LastInTargetRange;

	// Token: 0x04009471 RID: 38001
	private const string EFFECT_PATH = "/Game/Aki/Effect/EffectGroup/BigWorld/LHL/DA_Fx_Group_Sl2_LHL_Guangzhu_60M.DA_Fx_Group_Sl2_LHL_Guangzhu_60M";

	// Token: 0x04009472 RID: 38002
	private static readonly FLinearColor LineTraceColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x04009473 RID: 38003
	private const string TEXT_TARGET_NAME_KEY = "FlagChallenge_BossWarning";

	// Token: 0x02008980 RID: 35200
	[NullableContext(0)]
	private class EViewComponent
	{
		// Token: 0x0402E64D RID: 190029
		public const int DirectionItem = 0;

		// Token: 0x0402E64E RID: 190030
		public const int DefaultContent = 1;

		// Token: 0x0402E64F RID: 190031
		public const int MainContent = 2;

		// Token: 0x0402E650 RID: 190032
		public const int LockContent = 3;

		// Token: 0x0402E651 RID: 190033
		public const int MainEffect = 4;

		// Token: 0x0402E652 RID: 190034
		public const int PnlInfo = 5;

		// Token: 0x0402E653 RID: 190035
		public const int LockDefaultContent = 6;

		// Token: 0x0402E654 RID: 190036
		public const int LockMainContent = 7;

		// Token: 0x0402E655 RID: 190037
		public const int TargetNameText = 8;
	}
}

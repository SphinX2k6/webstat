using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree.Express;
using UnrealEngine;

// Token: 0x02001DBF RID: 7615
[NullableContext(2)]
[Nullable(0)]
public class NodeTrackEffect : IStaticVariableResetter
{
	// Token: 0x0600E143 RID: 57667 RVA: 0x003C91F0 File Offset: 0x003C73F0
	static NodeTrackEffect()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(NodeTrackEffect.CreateStaticDefaultValue), new Action(NodeTrackEffect.ResetStaticDefaultValue));
	}

	// Token: 0x0600E144 RID: 57668 RVA: 0x003C9210 File Offset: 0x003C7410
	[NullableContext(1)]
	public NodeTrackEffect(BehaviorTreeExpressionComponent owner, int nodeId, ITrackEffectAutoChange effectOption)
	{
		if (NodeTrackEffect.LineTrace == null)
		{
			NodeTrackEffect.InitLineTrace();
		}
		this.NodeId = nodeId;
		this.Owner = owner;
		this.TrackEffectEnterRange = (double)effectOption.EnterRange;
		this.TrackEffectLeaveRange = (double)effectOption.LeaveRange;
		this.HitLocation = Vector.Create();
	}

	// Token: 0x0600E145 RID: 57669 RVA: 0x003C9262 File Offset: 0x003C7462
	public void Destroy()
	{
		this.End();
		this.Owner = null;
	}

	// Token: 0x0600E146 RID: 57670 RVA: 0x003C9271 File Offset: 0x003C7471
	private static void InitLineTrace()
	{
		UTraceLineElement utraceLineElement = new UTraceLineElement();
		utraceLineElement.WorldContextObject = GlobalData.World;
		utraceLineElement.bIsSingle = true;
		utraceLineElement.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
		NodeTrackEffect.LineTrace = utraceLineElement;
	}

	// Token: 0x0600E147 RID: 57671 RVA: 0x003C929C File Offset: 0x003C749C
	public void OnBattleViewActive()
	{
		double trackDistance = this.Owner.GetTrackDistance(this.NodeId);
		this.IsInEnterRange = (trackDistance < this.TrackEffectEnterRange);
		NodeTrackEffect.SetTrackEffectActive(this.LongLightBeam, !this.IsInEnterRange);
		NodeTrackEffect.SetTrackEffectActive(this.ShortLightBeam, this.IsInEnterRange);
		if (this.Timer == null || !this.Timer.IsPause())
		{
			return;
		}
		this.Timer.Resume();
	}

	// Token: 0x0600E148 RID: 57672 RVA: 0x003C9311 File Offset: 0x003C7511
	public void OnBattleViewHide()
	{
		this.SetTrackedEffectHidden();
		if (this.Timer == null || this.Timer.IsPause())
		{
			return;
		}
		this.Timer.Pause();
	}

	// Token: 0x0600E149 RID: 57673 RVA: 0x003C933C File Offset: 0x003C753C
	public unsafe void Start()
	{
		this.IsInEnterRange = false;
		this.LoadedCompleteCount = 0;
		string trackEffectPath = ConfigBase<QuestNewConfig>.Instance.GetTrackEffectPath(ETrackEffect.LongLightBeam.ToEnumString());
		if (StringUtils.IsEmpty(trackEffectPath))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GeneralLogicTree;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到追踪特效配置路径";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("trackEffectType", ETrackEffect.LongLightBeam);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string trackEffectPath2 = ConfigBase<QuestNewConfig>.Instance.GetTrackEffectPath(ETrackEffect.ShortLightBeam.ToEnumString());
		if (StringUtils.IsEmpty(trackEffectPath2))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GeneralLogicTree;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "找不到追踪特效配置路径";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("trackEffectType", ETrackEffect.ShortLightBeam);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		Vector nodeTrackPosition = this.Owner.GetNodeTrackPosition(this.NodeId);
		if (nodeTrackPosition == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.GeneralLogicTree;
			ELogAuthor author3 = ELogAuthor.YSQ;
			string message3 = "找不到追踪位置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("trackEffectType", ETrackEffect.ShortLightBeam);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("nodeId", this.NodeId);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.LongLightBeam = this.CreateTrackEffect(ETrackEffect.LongLightBeam, trackEffectPath, nodeTrackPosition);
		this.ShortLightBeam = this.CreateTrackEffect(ETrackEffect.ShortLightBeam, trackEffectPath2, nodeTrackPosition);
	}

	// Token: 0x0600E14A RID: 57674 RVA: 0x003C9484 File Offset: 0x003C7684
	public void End()
	{
		if (this.Timer != null && TimerSystem.Instance.Has(this.Timer))
		{
			TimerSystem.Instance.Remove(this.Timer);
		}
		this.Timer = null;
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		if (this.LongLightBeam != 0 && instance.IsValid(this.LongLightBeam))
		{
			instance.StopEffectById(this.LongLightBeam, "[TrackEffectExpress.End]", true, null);
		}
		this.LongLightBeam = 0;
		if (this.ShortLightBeam != 0 && instance.IsValid(this.ShortLightBeam))
		{
			instance.StopEffectById(this.ShortLightBeam, "[TrackEffectExpress.End]", true, null);
		}
		this.ShortLightBeam = 0;
	}

	// Token: 0x0600E14B RID: 57675 RVA: 0x003C953C File Offset: 0x003C773C
	[NullableContext(1)]
	private int CreateTrackEffect(ETrackEffect effectType, string effectPath, IVector trackPosition)
	{
		UTraceLineElement lineTrace = NodeTrackEffect.LineTrace;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, trackPosition);
		lineTrace.SetEndLocation(trackPosition.X, trackPosition.Y, trackPosition.Z + 1000.0);
		this.HitLocation.FromUeVector(trackPosition);
		bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "TrackedMark_CreateTrackEffect");
		UKuroHitResult hitResult = lineTrace.HitResult;
		if (flag && hitResult.bBlockingHit)
		{
			this.HitLocation.Z = (double)hitResult.LocationZ_Array.Get(0);
		}
		this.HitLocation.Z -= 5.0;
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FVectorDouble fvectorDouble = this.HitLocation.ToUeVector(false);
		FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref Rotator.ZeroRotator, ref fvectorDouble, ref Vector.OneVector));
		return instance.SpawnEffect(world, ftransformDouble, effectPath, "[TrackEffectExpress.CreateTrackEffect]", null, EEffectType.Scene, null, delegate(ELoadEffectResult result, int handle)
		{
			if (result != ELoadEffectResult.Success)
			{
				return;
			}
			this.OnEffectLoadComplete(effectType, handle);
		}, null, false, false);
	}

	// Token: 0x0600E14C RID: 57676 RVA: 0x003C9640 File Offset: 0x003C7840
	private void OnEffectLoadComplete(ETrackEffect effectType, int handle)
	{
		Singleton<EffectSystem>.Instance.RegisterCustomCheckOwnerFunc(handle, (int _) => this.Owner != null);
		double trackDistance = this.Owner.GetTrackDistance(this.NodeId);
		this.IsInEnterRange = (trackDistance < this.TrackEffectEnterRange);
		bool bActive = (effectType == ETrackEffect.LongLightBeam) ? (!this.IsInEnterRange) : this.IsInEnterRange;
		NodeTrackEffect.SetTrackEffectActive(handle, bActive);
		this.LoadedCompleteCount++;
		if (this.LoadedCompleteCount != 2)
		{
			return;
		}
		this.Timer = TimerSystem.Instance.Forever(new TTimerAction(this.UpdateTrackEffect), 1000f, 1f, null, null, true);
	}

	// Token: 0x0600E14D RID: 57677 RVA: 0x003C96E4 File Offset: 0x003C78E4
	private void UpdateTrackEffect(float _)
	{
		if (this.IsOccupied)
		{
			this.SetTrackedEffectHidden();
			return;
		}
		double trackDistance = this.Owner.GetTrackDistance(this.NodeId);
		if (trackDistance <= 0.0)
		{
			this.SetTrackedEffectHidden();
			return;
		}
		if (!this.IsInEnterRange && trackDistance < this.TrackEffectEnterRange)
		{
			this.IsInEnterRange = true;
			NodeTrackEffect.SetTrackEffectActive(this.LongLightBeam, false);
			NodeTrackEffect.SetTrackEffectActive(this.ShortLightBeam, true);
		}
		if (this.IsInEnterRange && trackDistance >= this.TrackEffectLeaveRange)
		{
			this.IsInEnterRange = false;
			NodeTrackEffect.SetTrackEffectActive(this.LongLightBeam, true);
			NodeTrackEffect.SetTrackEffectActive(this.ShortLightBeam, false);
		}
	}

	// Token: 0x0600E14E RID: 57678 RVA: 0x003C9785 File Offset: 0x003C7985
	private void SetTrackedEffectHidden()
	{
		NodeTrackEffect.SetTrackEffectActive(this.LongLightBeam, false);
		NodeTrackEffect.SetTrackEffectActive(this.ShortLightBeam, false);
	}

	// Token: 0x0600E14F RID: 57679 RVA: 0x003C979F File Offset: 0x003C799F
	private static void SetTrackEffectActive(int handle, bool bActive)
	{
		Singleton<EffectSystem>.Instance.SetEffectHidden(handle, !bActive, null, false);
	}

	// Token: 0x0600E150 RID: 57680 RVA: 0x003C97B2 File Offset: 0x003C79B2
	public void OnExpressOccupied()
	{
		this.IsOccupied = true;
	}

	// Token: 0x0600E151 RID: 57681 RVA: 0x003C97BB File Offset: 0x003C79BB
	public void OnExpressOccupationRelease()
	{
		this.IsOccupied = false;
	}

	// Token: 0x0600E152 RID: 57682 RVA: 0x003C97C4 File Offset: 0x003C79C4
	public static void CreateStaticDefaultValue()
	{
		NodeTrackEffect.LineTrace = null;
	}

	// Token: 0x0600E153 RID: 57683 RVA: 0x003C97CC File Offset: 0x003C79CC
	public static void ResetStaticDefaultValue()
	{
		NodeTrackEffect.LineTrace = null;
	}

	// Token: 0x04006BF2 RID: 27634
	[Nullable(1)]
	private const string PROFILE_KEY = "TrackedMark_CreateTrackEffect";

	// Token: 0x04006BF3 RID: 27635
	private const int OFFSET_Z = 1000;

	// Token: 0x04006BF4 RID: 27636
	private static UTraceLineElement LineTrace;

	// Token: 0x04006BF5 RID: 27637
	private BehaviorTreeExpressionComponent Owner;

	// Token: 0x04006BF6 RID: 27638
	private readonly int NodeId;

	// Token: 0x04006BF7 RID: 27639
	private int LongLightBeam;

	// Token: 0x04006BF8 RID: 27640
	private int ShortLightBeam;

	// Token: 0x04006BF9 RID: 27641
	private readonly double TrackEffectEnterRange;

	// Token: 0x04006BFA RID: 27642
	private readonly double TrackEffectLeaveRange;

	// Token: 0x04006BFB RID: 27643
	private readonly Vector HitLocation;

	// Token: 0x04006BFC RID: 27644
	private TimerHandle Timer;

	// Token: 0x04006BFD RID: 27645
	private int LoadedCompleteCount;

	// Token: 0x04006BFE RID: 27646
	private bool IsInEnterRange;

	// Token: 0x04006BFF RID: 27647
	private bool IsOccupied;
}

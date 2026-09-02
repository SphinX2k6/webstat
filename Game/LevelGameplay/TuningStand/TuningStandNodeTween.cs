using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A7A RID: 27258
	[NullableContext(1)]
	[Nullable(0)]
	public class TuningStandNodeTween
	{
		// Token: 0x060436BD RID: 276157 RVA: 0x0115E4E4 File Offset: 0x0115C6E4
		public TuningStandNodeTween(UUIItem nodeItem, string curveNameX)
		{
			this.NodeItem = nodeItem;
			this.CurveNameX = curveNameX;
			this.DelegateX = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.TweenCallX));
			this.DelegateZ = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.TweenCallZ));
			this.SequencePlayer = new LevelSequencePlayer(this.NodeItem);
		}

		// Token: 0x1700A268 RID: 41576
		// (get) Token: 0x060436BE RID: 276158 RVA: 0x0115E544 File Offset: 0x0115C744
		protected UUIItem NodeItem { get; }

		// Token: 0x1700A269 RID: 41577
		// (get) Token: 0x060436BF RID: 276159 RVA: 0x0115E54C File Offset: 0x0115C74C
		protected string CurveNameX { get; }

		// Token: 0x060436C0 RID: 276160 RVA: 0x0115E554 File Offset: 0x0115C754
		private void TweenCallX(float value)
		{
			FVectorDouble fvectorDouble = this.NodeItem.D_K2_GetComponentLocation();
			FVectorDouble newLocation = Vector.Create((double)value, fvectorDouble.Y, fvectorDouble.Z).ToUeVector(false);
			this.NodeItem.D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x060436C1 RID: 276161 RVA: 0x0115E59C File Offset: 0x0115C79C
		private void TweenCallZ(float value)
		{
			FVectorDouble fvectorDouble = this.NodeItem.D_K2_GetComponentLocation();
			FVectorDouble newLocation = Vector.Create(fvectorDouble.X, fvectorDouble.Y, (double)value).ToUeVector(false);
			this.NodeItem.D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x060436C2 RID: 276162 RVA: 0x0115E5E2 File Offset: 0x0115C7E2
		private void OnTweenerEndX()
		{
			if (this.TweenerX != null)
			{
				this.TweenerX = null;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TuningStandSuccessShowEnd);
		}

		// Token: 0x060436C3 RID: 276163 RVA: 0x0115E603 File Offset: 0x0115C803
		private void OnTweenerEndZ()
		{
			if (this.TweenerZ != null)
			{
				this.TweenerZ = null;
			}
		}

		// Token: 0x060436C4 RID: 276164 RVA: 0x0115E614 File Offset: 0x0115C814
		public UniTask InitCurveDamage()
		{
			TuningStandNodeTween.<InitCurveDamage>d__18 <InitCurveDamage>d__;
			<InitCurveDamage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveDamage>d__.<>4__this = this;
			<InitCurveDamage>d__.<>1__state = -1;
			<InitCurveDamage>d__.<>t__builder.Start<TuningStandNodeTween.<InitCurveDamage>d__18>(ref <InitCurveDamage>d__);
			return <InitCurveDamage>d__.<>t__builder.Task;
		}

		// Token: 0x060436C5 RID: 276165 RVA: 0x0115E658 File Offset: 0x0115C858
		public void PlayTween(FVectorDouble start, FVectorDouble end, bool needVisible = true)
		{
			this.TweenerX = ULTweenBPLibrary.FloatTo(GlobalData.World, this.DelegateX, (float)start.X, (float)end.X, 1f, 0f, LTweenEase.OutCubic);
			this.TweenerZ = ULTweenBPLibrary.FloatTo(GlobalData.World, this.DelegateZ, (float)start.Z, (float)end.Z, 1f, 0f, LTweenEase.OutCubic);
			this.NodeItem.SetUIActive(needVisible);
			this.NodeItem.D_K2_SetWorldLocation(start, false, ref WorldGlobal.SweepHitResult, false);
			this.SequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			if (this.TweenerX != null)
			{
				this.TweenerX.SetEase(LTweenEase.CurveFloat);
				this.TweenerX.SetCurveFloat(this.CurveX);
				this.TweenerX.OnCompleteCallBack.Bind(new Action(this.OnTweenerEndX));
			}
			if (this.TweenerZ != null)
			{
				this.TweenerZ.SetEase(LTweenEase.CurveFloat);
				this.TweenerZ.SetCurveFloat(this.CurveZ);
				this.TweenerZ.OnCompleteCallBack.Bind(new Action(this.OnTweenerEndZ));
			}
		}

		// Token: 0x060436C6 RID: 276166 RVA: 0x0115E788 File Offset: 0x0115C988
		public void Clear()
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.TweenCallX));
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.TweenCallZ));
			this.CurveX = null;
			this.CurveZ = null;
			if (this.TweenerX != null)
			{
				this.TweenerX = null;
			}
			if (this.TweenerZ != null)
			{
				this.TweenerZ = null;
			}
			this.SequencePlayer = null;
		}

		// Token: 0x04025A63 RID: 154211
		[Nullable(2)]
		protected ULTweener TweenerX;

		// Token: 0x04025A64 RID: 154212
		[Nullable(2)]
		protected ULTweener TweenerZ;

		// Token: 0x04025A65 RID: 154213
		protected FLTweenFloatSetterDynamic DelegateX;

		// Token: 0x04025A66 RID: 154214
		protected FLTweenFloatSetterDynamic DelegateZ;

		// Token: 0x04025A67 RID: 154215
		[Nullable(2)]
		protected UCurveFloat CurveX;

		// Token: 0x04025A68 RID: 154216
		[Nullable(2)]
		protected UCurveFloat CurveZ;

		// Token: 0x04025A69 RID: 154217
		[Nullable(2)]
		protected LevelSequencePlayer SequencePlayer;
	}
}

using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit
{
	// Token: 0x02006A9C RID: 27292
	[NullableContext(2)]
	[Nullable(0)]
	public class SunSpiritData
	{
		// Token: 0x060437EA RID: 276458 RVA: 0x01164C96 File Offset: 0x01162E96
		public SunSpiritData(int sunSpiritId)
		{
			this.SunSpiritId = sunSpiritId;
			this.State = new SunSpiritNoneState(this);
			this.Perform = new SunSpiritNonePerform(this, Singleton<MathUtils>.Instance.DefaultTransformProxy);
		}

		// Token: 0x1700A273 RID: 41587
		// (get) Token: 0x060437EB RID: 276459 RVA: 0x01164CD3 File Offset: 0x01162ED3
		public ESunSpiritStateType StateType
		{
			get
			{
				return this.State.StateType;
			}
		}

		// Token: 0x060437EC RID: 276460 RVA: 0x01164CE0 File Offset: 0x01162EE0
		public void StopCurrentSunSpiritState()
		{
			this.State.IsFinished = true;
		}

		// Token: 0x060437ED RID: 276461 RVA: 0x01164CEE File Offset: 0x01162EEE
		public void StopAllSunSpiritState()
		{
			this.State.IsFinished = true;
			this.PendingStateQueue.Clear();
		}

		// Token: 0x060437EE RID: 276462 RVA: 0x01164D07 File Offset: 0x01162F07
		[NullableContext(1)]
		public void SetNextSunSpiritState(SunSpiritBaseState newState)
		{
			this.PendingStateQueue.Push(newState);
		}

		// Token: 0x060437EF RID: 276463 RVA: 0x01164D18 File Offset: 0x01162F18
		[NullableContext(1)]
		public void StopAllAndSetNextSunSpiritState(SunSpiritBaseState newState, bool bDoIfSameState = false)
		{
			if (!bDoIfSameState && this.PendingStateQueue.Size == 0 && this.State.IsSameState(newState))
			{
				Singleton<Log>.Instance.Info(ELogModule.SunSpirit, ELogAuthor.ZYL, "日灵: 当前状态和目标状态相同，不执行切换", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.StopAllSunSpiritState();
			this.SetNextSunSpiritState(newState);
		}

		// Token: 0x060437F0 RID: 276464 RVA: 0x01164D70 File Offset: 0x01162F70
		[NullableContext(1)]
		public SunSpiritBaseState GetSunSpiritState()
		{
			return this.State;
		}

		// Token: 0x060437F1 RID: 276465 RVA: 0x01164D78 File Offset: 0x01162F78
		public void TickState(float deltaSeconds)
		{
			if (this.State.IsFinished)
			{
				this.State.Exit();
				if (this.PendingStateQueue.Size > 0)
				{
					this.State = this.PendingStateQueue.Pop();
				}
				else
				{
					this.State = new SunSpiritNoneState(this);
				}
				if (!this.State.Enter())
				{
					this.State.IsFinished = true;
				}
			}
			if (!this.State.IsFinished)
			{
				this.State.Tick(deltaSeconds);
			}
		}

		// Token: 0x060437F2 RID: 276466 RVA: 0x01164DFC File Offset: 0x01162FFC
		[NullableContext(1)]
		public SunSpiritBasePerform GetSunSpiritPerform()
		{
			return this.Perform;
		}

		// Token: 0x060437F3 RID: 276467 RVA: 0x01164E04 File Offset: 0x01163004
		[NullableContext(1)]
		public void ChangeSunSpiritPerform(SunSpiritBasePerform newPerform)
		{
			SunSpiritBasePerform perform = this.Perform;
			this.Perform = newPerform;
			global::Transform transform = global::Transform.Create();
			((ISunSpiritScenePerform)perform).GetTransform(transform);
			perform.Destroy();
			if (!this.Perform.Init())
			{
				this.Perform = new SunSpiritNonePerform(this, transform);
				this.Perform.Init();
			}
		}

		// Token: 0x060437F4 RID: 276468 RVA: 0x01164E5C File Offset: 0x0116305C
		[NullableContext(1)]
		public void SetOrUpdateSunSpiritBasicDataByProto(SunSpiritPb sunSpiritPb)
		{
			this.PbData = sunSpiritPb;
			this.ConfigId = sunSpiritPb.EntityConfigId;
			this.PlayerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			this.InstId = sunSpiritPb.InstId;
			this.AreaId = ModelBase<SunSpiritModel>.Instance.GetSunSpiritAreaIdByConfigId(this.InstId, this.ConfigId);
		}

		// Token: 0x060437F5 RID: 276469 RVA: 0x01164EB4 File Offset: 0x011630B4
		public void RefreshSunSpiritStateByCachedProto(bool bDoIfSameState)
		{
			if (this.PbData == null)
			{
				return;
			}
			if (!ModelBase<SunSpiritModel>.Instance.GetIsSunSpiritEnable())
			{
				this.StopAllAndSetNextSunSpiritState(new SunSpiritNoneState(this), bDoIfSameState);
				return;
			}
			SunSpiritTakeUpPb takeUpData = this.PbData.TakeUpData;
			if (takeUpData != null && takeUpData.TrapEntityConfigId != 0)
			{
				SunSpiritTakeUpPb takeUpData2 = this.PbData.TakeUpData;
				int gearConfigId = (takeUpData2 != null) ? takeUpData2.TrapEntityConfigId : 0;
				SunSpiritTakeUpPb takeUpData3 = this.PbData.TakeUpData;
				this.StopAllAndSetNextSunSpiritState(new SunSpiritOccupiedByGearState(this, gearConfigId, (takeUpData3 != null) ? takeUpData3.Index : 0), bDoIfSameState);
				return;
			}
			this.StopAllAndSetNextSunSpiritState(new SunSpiritOccupiedByPlayerState(this), bDoIfSameState);
		}

		// Token: 0x1700A274 RID: 41588
		// (get) Token: 0x060437F6 RID: 276470 RVA: 0x01164F48 File Offset: 0x01163148
		public global::Vector Location
		{
			get
			{
				if (this.LocationCachedTime < Singleton<Time>.Instance.Frame)
				{
					if (this.LocationCache == null)
					{
						this.LocationCache = global::Vector.Create();
					}
					if (!((ISunSpiritScenePerform)this.Perform).GetTransformData(this.LocationCache, null, null))
					{
						return null;
					}
					this.LocationCachedTime = Singleton<Time>.Instance.Frame;
				}
				return this.LocationCache;
			}
		}

		// Token: 0x1700A275 RID: 41589
		// (get) Token: 0x060437F7 RID: 276471 RVA: 0x01164FAC File Offset: 0x011631AC
		public global::Rotator Rotator
		{
			get
			{
				if (this.RotationCachedTime < Singleton<Time>.Instance.Frame)
				{
					if (this.RotatorCache == null)
					{
						this.RotatorCache = global::Rotator.Create();
					}
					if (this.QuaternionCache == null)
					{
						this.QuaternionCache = Quat.Create(0f, 0f, 0f, 1f);
					}
					if (!((ISunSpiritScenePerform)this.Perform).GetTransformData(null, this.RotatorCache, null))
					{
						return null;
					}
					this.RotatorCache.Quaternion(this.QuaternionCache);
					this.RotationCachedTime = Singleton<Time>.Instance.Frame;
				}
				return this.RotatorCache;
			}
		}

		// Token: 0x1700A276 RID: 41590
		// (get) Token: 0x060437F8 RID: 276472 RVA: 0x01165049 File Offset: 0x01163249
		public Quat Quaternion
		{
			get
			{
				global::Rotator rotator = this.Rotator;
				if (rotator == null)
				{
					return null;
				}
				return rotator.Quaternion(this.QuaternionCache);
			}
		}

		// Token: 0x1700A277 RID: 41591
		// (get) Token: 0x060437F9 RID: 276473 RVA: 0x01165064 File Offset: 0x01163264
		public global::Vector Scale3D
		{
			get
			{
				if (this.ScaleCachedTime < Singleton<Time>.Instance.Frame)
				{
					if (this.ScaleCache == null)
					{
						this.ScaleCache = global::Vector.Create();
					}
					if (!((ISunSpiritScenePerform)this.Perform).GetTransformData(null, null, this.ScaleCache))
					{
						return null;
					}
					this.ScaleCachedTime = Singleton<Time>.Instance.Frame;
				}
				return this.ScaleCache;
			}
		}

		// Token: 0x1700A278 RID: 41592
		// (get) Token: 0x060437FA RID: 276474 RVA: 0x011650C8 File Offset: 0x011632C8
		public global::Transform Transform
		{
			get
			{
				if (this.TransformCacheTime < Singleton<Time>.Instance.Frame)
				{
					if (this.TransformCache == null)
					{
						this.TransformCache = global::Transform.Create();
					}
					if (!((ISunSpiritScenePerform)this.Perform).GetTransform(this.TransformCache))
					{
						return null;
					}
					this.TransformCacheTime = Singleton<Time>.Instance.Frame;
				}
				return this.TransformCache;
			}
		}

		// Token: 0x060437FB RID: 276475 RVA: 0x0116512C File Offset: 0x0116332C
		[NullableContext(1)]
		public void SetLocation(global::Vector value)
		{
			if (this.LocationCache == null)
			{
				this.LocationCache = global::Vector.Create();
			}
			this.LocationCache.FromUeVector(value);
			this.LocationCachedTime = Singleton<Time>.Instance.Frame;
			((ISunSpiritScenePerform)this.Perform).SetTransformData(this.LocationCache, null, null);
		}

		// Token: 0x060437FC RID: 276476 RVA: 0x01165184 File Offset: 0x01163384
		public void SetRotation(object value)
		{
			if (this.RotatorCache == null)
			{
				this.RotatorCache = global::Rotator.Create();
			}
			if (this.QuaternionCache == null)
			{
				this.QuaternionCache = Quat.Create(0f, 0f, 0f, 1f);
			}
			IQuat quat = value as IQuat;
			if (quat != null)
			{
				this.QuaternionCache.FromUeQuat(quat);
				this.QuaternionCache.Rotator(this.RotatorCache);
			}
			else
			{
				IRotator rotator = value as IRotator;
				if (rotator != null)
				{
					this.RotatorCache.FromUeRotator(rotator);
				}
			}
			this.RotatorCache.Quaternion(this.QuaternionCache);
			this.RotationCachedTime = Singleton<Time>.Instance.Frame;
			((ISunSpiritScenePerform)this.Perform).SetTransformData(null, this.RotatorCache, null);
		}

		// Token: 0x060437FD RID: 276477 RVA: 0x01165248 File Offset: 0x01163448
		[NullableContext(1)]
		public void SetLocationAndRotation(global::Vector location, [Nullable(2)] object rotation)
		{
			if (this.RotatorCache == null)
			{
				this.RotatorCache = global::Rotator.Create();
			}
			if (this.QuaternionCache == null)
			{
				this.QuaternionCache = Quat.Create(0f, 0f, 0f, 1f);
			}
			if (this.LocationCache == null)
			{
				this.LocationCache = global::Vector.Create();
			}
			this.LocationCache.FromUeVector(location);
			IQuat quat = rotation as IQuat;
			if (quat != null)
			{
				this.QuaternionCache.FromUeQuat(quat);
				this.QuaternionCache.Rotator(this.RotatorCache);
			}
			else
			{
				IRotator rotator = rotation as IRotator;
				if (rotator != null)
				{
					this.RotatorCache.FromUeRotator(rotator);
				}
			}
			this.RotatorCache.Quaternion(this.QuaternionCache);
			this.RotationCachedTime = Singleton<Time>.Instance.Frame;
			((ISunSpiritScenePerform)this.Perform).SetTransformData(this.LocationCache, this.RotatorCache, null);
		}

		// Token: 0x060437FE RID: 276478 RVA: 0x01165330 File Offset: 0x01163530
		[NullableContext(1)]
		public void SetScale3D(global::Vector value)
		{
			if (this.ScaleCache == null)
			{
				this.ScaleCache = global::Vector.Create();
			}
			this.ScaleCache.FromUeVector(value);
			this.ScaleCachedTime = Singleton<Time>.Instance.Frame;
			((ISunSpiritScenePerform)this.Perform).SetTransformData(null, null, this.ScaleCache);
		}

		// Token: 0x060437FF RID: 276479 RVA: 0x01165388 File Offset: 0x01163588
		[NullableContext(1)]
		public void SetTransform(global::Transform transform)
		{
			if (this.TransformCache == null)
			{
				this.TransformCache = global::Transform.Create();
			}
			this.TransformCache.Set(transform.GetLocation(), transform.GetRotation(), transform.GetScale3D());
			this.TransformCacheTime = Singleton<Time>.Instance.Frame;
			((ISunSpiritScenePerform)this.Perform).SetTransform(this.TransformCache);
		}

		// Token: 0x06043800 RID: 276480 RVA: 0x011653EC File Offset: 0x011635EC
		public void SetTransform(FTransform transform)
		{
			if (this.TransformCache == null)
			{
				this.TransformCache = global::Transform.Create();
			}
			this.TransformCache.Set(transform.GetLocation(), transform.GetRotation(), transform.GetScale3D());
			this.TransformCacheTime = Singleton<Time>.Instance.Frame;
			((ISunSpiritScenePerform)this.Perform).SetTransform(this.TransformCache);
		}

		// Token: 0x04025B3D RID: 154429
		public readonly int SunSpiritId;

		// Token: 0x04025B3E RID: 154430
		public int InstId;

		// Token: 0x04025B3F RID: 154431
		public int ConfigId;

		// Token: 0x04025B40 RID: 154432
		public int AreaId;

		// Token: 0x04025B41 RID: 154433
		public int PlayerId;

		// Token: 0x04025B42 RID: 154434
		public SunSpiritPb PbData;

		// Token: 0x04025B43 RID: 154435
		[Nullable(1)]
		private SunSpiritBaseState State;

		// Token: 0x04025B44 RID: 154436
		[Nullable(1)]
		private readonly Queue<SunSpiritBaseState> PendingStateQueue = new Queue<SunSpiritBaseState>(4);

		// Token: 0x04025B45 RID: 154437
		[Nullable(1)]
		private SunSpiritBasePerform Perform;

		// Token: 0x04025B46 RID: 154438
		private global::Vector LocationCache;

		// Token: 0x04025B47 RID: 154439
		private int LocationCachedTime;

		// Token: 0x04025B48 RID: 154440
		private Quat QuaternionCache;

		// Token: 0x04025B49 RID: 154441
		private global::Rotator RotatorCache;

		// Token: 0x04025B4A RID: 154442
		private int RotationCachedTime;

		// Token: 0x04025B4B RID: 154443
		private global::Vector ScaleCache;

		// Token: 0x04025B4C RID: 154444
		private int ScaleCachedTime;

		// Token: 0x04025B4D RID: 154445
		private global::Transform TransformCache;

		// Token: 0x04025B4E RID: 154446
		private int TransformCacheTime;
	}
}

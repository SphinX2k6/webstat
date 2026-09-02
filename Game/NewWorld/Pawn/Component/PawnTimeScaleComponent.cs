using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Pawn.Component
{
	// Token: 0x020048B6 RID: 18614
	[NullableContext(1)]
	[Nullable(0)]
	public class PawnTimeScaleComponent : EntityComponent
	{
		// Token: 0x0603084E RID: 198734 RVA: 0x00BE99AC File Offset: 0x00BE7BAC
		public static ESourceEffectGroup getSourceEffectGroup(ETimeScaleSourceType sourceType)
		{
			foreach (KeyValuePair<ESourceEffectGroup, List<ETimeScaleSourceType>> keyValuePair in PawnTimeScaleComponent.sourceEffectGroup)
			{
				ESourceEffectGroup esourceEffectGroup;
				List<ETimeScaleSourceType> list;
				keyValuePair.Deconstruct(out esourceEffectGroup, out list);
				ESourceEffectGroup result = esourceEffectGroup;
				if (list.Contains(sourceType))
				{
					return result;
				}
			}
			return ESourceEffectGroup.LogicAndView;
		}

		// Token: 0x0603084F RID: 198735 RVA: 0x00BE9A18 File Offset: 0x00BE7C18
		public static ETimeScaleSourceGroup getSourceGroup(ETimeScaleSourceType sourceType)
		{
			foreach (KeyValuePair<ETimeScaleSourceGroup, List<ETimeScaleSourceType>> keyValuePair in PawnTimeScaleComponent.sourceTypeGroup)
			{
				ETimeScaleSourceGroup etimeScaleSourceGroup;
				List<ETimeScaleSourceType> list;
				keyValuePair.Deconstruct(out etimeScaleSourceGroup, out list);
				ETimeScaleSourceGroup result = etimeScaleSourceGroup;
				if (list.Contains(sourceType))
				{
					return result;
				}
			}
			return ETimeScaleSourceGroup.Default;
		}

		// Token: 0x06030850 RID: 198736 RVA: 0x00BE9A84 File Offset: 0x00BE7C84
		public static int CompareScalePriority(ForeverTimeScale scale1, ForeverTimeScale scale2)
		{
			if (scale1.SourceTypeGroup != scale2.SourceTypeGroup)
			{
				return scale2.SourceTypeGroup - scale1.SourceTypeGroup;
			}
			if (scale1.Priority != scale2.Priority)
			{
				return scale2.Priority - scale1.Priority;
			}
			if (scale1.TimeDilation != scale2.TimeDilation)
			{
				return scale1.TimeDilation.CompareTo(scale2.TimeDilation);
			}
			return scale2.EndTime.CompareTo(scale1.EndTime);
		}

		// Token: 0x06030851 RID: 198737 RVA: 0x00BE9B00 File Offset: 0x00BE7D00
		public static int CompareScalePriority(TimeScale scale1, TimeScale scale2)
		{
			if (scale1.SourceTypeGroup != scale2.SourceTypeGroup)
			{
				return scale2.SourceTypeGroup - scale1.SourceTypeGroup;
			}
			if (scale1.Priority != scale2.Priority)
			{
				return scale2.Priority - scale1.Priority;
			}
			if (scale1.TimeDilation != scale2.TimeDilation)
			{
				return scale1.TimeDilation.CompareTo(scale2.TimeDilation);
			}
			return scale2.EndTime.CompareTo(scale1.EndTime);
		}

		// Token: 0x06030852 RID: 198738 RVA: 0x00BE9B78 File Offset: 0x00BE7D78
		protected override bool OnInit()
		{
			this.TimeScaleList.Clear();
			this.TimeScaleMap.Clear();
			this.ForeverTimeScaleLogicView.Clear();
			this.ForeverTimeScaleViewOnly.Clear();
			this.ForeverTimeScaleMap.Clear();
			this.TimeScaleId = 1;
			this.KeyedTimeScaleLocks.Clear();
			return true;
		}

		// Token: 0x06030853 RID: 198739 RVA: 0x00BE9BD0 File Offset: 0x00BE7DD0
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
			this.HitComp = base.Entity.GetComponent<CharacterHitComponent>();
			SEntityProperty entityPropertyConfig = this.ActorComp.CreatureData.GetEntityPropertyConfig();
			this.BulletHitDiscount = (float)entityPropertyConfig.子弹受击顿帧时长比例 / 100f;
			return true;
		}

		// Token: 0x06030854 RID: 198740 RVA: 0x00BE9C24 File Offset: 0x00BE7E24
		protected virtual bool IsTimescaleValid(TimeScale timescale, float currentTime)
		{
			return timescale.EndTime > timescale.GetCurrentTime() && !timescale.MarkDelete;
		}

		// Token: 0x06030855 RID: 198741 RVA: 0x00BE9C3F File Offset: 0x00BE7E3F
		protected override void OnTick(float delta)
		{
		}

		// Token: 0x06030856 RID: 198742 RVA: 0x00BE9C44 File Offset: 0x00BE7E44
		[NullableContext(2)]
		private int SetTimeScaleInternal(int priority, float timeDilation, UCurveFloat curve, float duration, ETimeScaleSourceType sourceType, bool needAddSceneItemTag = false, bool immuneSelfCenter = false)
		{
			if (sourceType == ETimeScaleSourceType.OthersBullet)
			{
				duration *= this.BulletHitDiscount;
			}
			if (duration <= 0f)
			{
				return -1;
			}
			double num = immuneSelfCenter ? Singleton<Time>.Instance.PlayerWorldTimeSeconds : Singleton<Time>.Instance.WorldTimeSeconds;
			double num2 = num + (double)duration;
			double endTime = num2;
			float timeDilation2 = Math.Max(timeDilation, 0f);
			float duration2 = duration;
			int timeScaleId = this.TimeScaleId;
			this.TimeScaleId = timeScaleId + 1;
			TimeScale timeScale = new TimeScale(num, endTime, priority, timeDilation2, curve, duration2, timeScaleId, sourceType, PawnTimeScaleComponent.getSourceGroup(sourceType), needAddSceneItemTag, immuneSelfCenter);
			this.TimeScaleList.Push(timeScale);
			this.TimeScaleMap[timeScale.Id] = timeScale;
			return timeScale.Id;
		}

		// Token: 0x06030857 RID: 198743 RVA: 0x00BE9CE4 File Offset: 0x00BE7EE4
		[NullableContext(2)]
		public virtual int SetTimeScale(int priority, float timeDilation, UCurveFloat curve, float duration, ETimeScaleSourceType sourceType, bool needAddSceneItemTag = false, bool immuneSelfCenter = false)
		{
			return this.SetTimeScaleInternal(priority, timeDilation, curve, duration, sourceType, needAddSceneItemTag, immuneSelfCenter);
		}

		// Token: 0x06030858 RID: 198744 RVA: 0x00BE9CF8 File Offset: 0x00BE7EF8
		private void RemoveTimeScaleInternal(int id)
		{
			TimeScale timeScale;
			if (this.TimeScaleMap.TryGetValue(id, out timeScale))
			{
				timeScale.MarkDelete = true;
			}
		}

		// Token: 0x06030859 RID: 198745 RVA: 0x00BE9D1C File Offset: 0x00BE7F1C
		public virtual void RemoveTimeScale(int id)
		{
			this.RemoveTimeScaleInternal(id);
		}

		// Token: 0x0603085A RID: 198746 RVA: 0x00BE9D28 File Offset: 0x00BE7F28
		public void RemoveAllTimeScale()
		{
			foreach (TimeScale timeScale in this.TimeScaleMap.Values)
			{
				timeScale.MarkDelete = true;
			}
		}

		// Token: 0x0603085B RID: 198747 RVA: 0x00BE9D80 File Offset: 0x00BE7F80
		public virtual int SetForeverTimeScale(ETimeScaleSourceType type, float timeScale, int priority = 0, bool refreshImmediately = false)
		{
			ETimeScaleSourceGroup sourceGroup = PawnTimeScaleComponent.getSourceGroup(type);
			int timeScaleId = this.TimeScaleId;
			this.TimeScaleId = timeScaleId + 1;
			ForeverTimeScale foreverTimeScale = new ForeverTimeScale(priority, timeScale, type, sourceGroup, timeScaleId);
			if (PawnTimeScaleComponent.getSourceEffectGroup(type) == ESourceEffectGroup.ViewOnly)
			{
				this.ForeverTimeScaleViewOnly.Push(foreverTimeScale);
			}
			else
			{
				this.ForeverTimeScaleLogicView.Push(foreverTimeScale);
			}
			this.ForeverTimeScaleMap[foreverTimeScale.Id] = foreverTimeScale;
			if (refreshImmediately)
			{
				this.OnTick(0f);
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<ETimeScaleSourceType, float, int>(base.Entity, EEventName.OnForeverTimeDilationAdd, type, timeScale, priority);
			return foreverTimeScale.Id;
		}

		// Token: 0x0603085C RID: 198748 RVA: 0x00BE9E10 File Offset: 0x00BE8010
		public virtual void RemoveForeverTimeScale(int id, bool refreshImmediately = false)
		{
			ForeverTimeScale foreverTimeScale;
			if (this.ForeverTimeScaleMap.TryGetValue(id, out foreverTimeScale))
			{
				foreverTimeScale.MarkDelete = true;
				if (refreshImmediately)
				{
					this.OnTick(0f);
				}
				Singleton<EventSystem>.Instance.EmitWithTarget<ETimeScaleSourceType, float, int>(base.Entity, EEventName.OnForeverTimeDilationRemove, foreverTimeScale.SourceType, foreverTimeScale.TimeDilation, foreverTimeScale.Priority);
			}
		}

		// Token: 0x0603085D RID: 198749 RVA: 0x00BE9E6C File Offset: 0x00BE806C
		public float GetForeverTimeScale(int id)
		{
			ForeverTimeScale foreverTimeScale2;
			ForeverTimeScale foreverTimeScale = this.ForeverTimeScaleMap.TryGetValue(id, out foreverTimeScale2) ? foreverTimeScale2 : null;
			if (foreverTimeScale == null)
			{
				return 1f;
			}
			return foreverTimeScale.TimeDilation;
		}

		// Token: 0x0603085E RID: 198750 RVA: 0x00BE9EA0 File Offset: 0x00BE80A0
		[NullableContext(2)]
		public virtual void SetTimeScaleTicking(bool enable, string reason = null)
		{
			if (enable && this.DisableHandle != null)
			{
				if (base.Enable(new int?(this.DisableHandle.Value), reason ?? "[PawnTimeScaleComponent] 开启Tick"))
				{
					this.DisableHandle = null;
					return;
				}
			}
			else if (!enable && this.DisableHandle == null)
			{
				this.DisableHandle = new int?(base.Disable(reason ?? "[PawnTimeScaleComponent] 关闭Tick"));
			}
		}

		// Token: 0x170082BE RID: 33470
		// (get) Token: 0x0603085F RID: 198751 RVA: 0x00BE9F17 File Offset: 0x00BE8117
		public float CurrentTimeScale
		{
			get
			{
				return this.TimeScaleInternal;
			}
		}

		// Token: 0x170082BF RID: 33471
		// (get) Token: 0x06030860 RID: 198752 RVA: 0x00BE9F1F File Offset: 0x00BE811F
		public float FreezeTimeScale
		{
			get
			{
				return this.FreezeTimeScaleInternal;
			}
		}

		// Token: 0x06030861 RID: 198753 RVA: 0x00BE9F27 File Offset: 0x00BE8127
		[NullableContext(2)]
		private int SetLocalTimeScale(int priority, float timeDilation, UCurveFloat curve, float duration, ETimeScaleSourceType sourceType, bool needAddSceneItemTag = false, bool immuneSelfCenter = false)
		{
			return this.SetTimeScaleInternal(priority, timeDilation, curve, duration, sourceType, needAddSceneItemTag, immuneSelfCenter);
		}

		// Token: 0x06030862 RID: 198754 RVA: 0x00BE9F3A File Offset: 0x00BE813A
		private void ResetLocalTimeScale(int id)
		{
			this.RemoveTimeScaleInternal(id);
		}

		// Token: 0x06030863 RID: 198755 RVA: 0x00BE9F44 File Offset: 0x00BE8144
		private void SetKeyedTimeScaleLock(string key, ETimeScaleSourceType sourceType, float scale, bool refreshImmediately = false, bool needImmuneCheck = false)
		{
			PawnTimeScaleComponent.KeyedTimeScaleLock keyedTimeScaleLock;
			if (this.KeyedTimeScaleLocks.TryGetValue(key, out keyedTimeScaleLock) && keyedTimeScaleLock.Handle >= 0 && keyedTimeScaleLock.Scale == scale && keyedTimeScaleLock.SourceType == sourceType && keyedTimeScaleLock.NeedImmuneCheck == needImmuneCheck)
			{
				return;
			}
			this.ResetKeyedTimeScaleLock(key, false);
			int handle = -1;
			if (needImmuneCheck)
			{
				CharacterHitComponent hitComp = this.HitComp;
				if (hitComp != null && hitComp.IsImmuneTimeScaleEffect())
				{
					goto IL_6E;
				}
			}
			handle = this.SetLocalTimeScale(int.MaxValue, scale, null, float.PositiveInfinity, sourceType, false, false);
			IL_6E:
			this.KeyedTimeScaleLocks[key] = new PawnTimeScaleComponent.KeyedTimeScaleLock
			{
				Handle = handle,
				Scale = scale,
				SourceType = sourceType,
				NeedImmuneCheck = needImmuneCheck
			};
			if (refreshImmediately)
			{
				this.OnTick(0f);
			}
		}

		// Token: 0x06030864 RID: 198756 RVA: 0x00BE9FFC File Offset: 0x00BE81FC
		private void ResetKeyedTimeScaleLock(string key, bool refreshImmediately = false)
		{
			PawnTimeScaleComponent.KeyedTimeScaleLock keyedTimeScaleLock;
			if (!this.KeyedTimeScaleLocks.TryGetValue(key, out keyedTimeScaleLock))
			{
				return;
			}
			if (keyedTimeScaleLock.Handle >= 0)
			{
				this.ResetLocalTimeScale(keyedTimeScaleLock.Handle);
			}
			this.KeyedTimeScaleLocks.Remove(key);
			if (refreshImmediately)
			{
				this.OnTick(0f);
			}
		}

		// Token: 0x06030865 RID: 198757 RVA: 0x00BEA04C File Offset: 0x00BE824C
		public void AddPauseLock(string key)
		{
			this.SetKeyedTimeScaleLock(key, ETimeScaleSourceType.InnerPauseLock, 0f, false, true);
			PawnTimeScaleComponent.KeyedTimeScaleLock keyedTimeScaleLock;
			this.PauseLocks[key] = (this.KeyedTimeScaleLocks.TryGetValue(key, out keyedTimeScaleLock) ? keyedTimeScaleLock.Handle : -1);
		}

		// Token: 0x06030866 RID: 198758 RVA: 0x00BEA08E File Offset: 0x00BE828E
		public void RemovePauseLock(string key)
		{
			this.ResetKeyedTimeScaleLock(key, false);
			this.PauseLocks.Remove(key);
		}

		// Token: 0x06030867 RID: 198759 RVA: 0x00BEA0A8 File Offset: 0x00BE82A8
		public void ImmunePauseLock()
		{
			foreach (string key in this.PauseLocks.Keys.ToList<string>())
			{
				PawnTimeScaleComponent.KeyedTimeScaleLock keyedTimeScaleLock;
				if (this.KeyedTimeScaleLocks.TryGetValue(key, out keyedTimeScaleLock) && keyedTimeScaleLock.Handle >= 0)
				{
					this.ResetLocalTimeScale(keyedTimeScaleLock.Handle);
					keyedTimeScaleLock.Handle = -1;
					this.KeyedTimeScaleLocks[key] = keyedTimeScaleLock;
					this.PauseLocks[key] = -1;
				}
			}
		}

		// Token: 0x06030868 RID: 198760 RVA: 0x00BEA144 File Offset: 0x00BE8344
		public void ResumePauseLock()
		{
			foreach (string key in this.PauseLocks.Keys.ToList<string>())
			{
				this.SetKeyedTimeScaleLock(key, ETimeScaleSourceType.InnerPauseLock, 0f, false, true);
				PawnTimeScaleComponent.KeyedTimeScaleLock keyedTimeScaleLock;
				this.PauseLocks[key] = (this.KeyedTimeScaleLocks.TryGetValue(key, out keyedTimeScaleLock) ? keyedTimeScaleLock.Handle : -1);
			}
		}

		// Token: 0x06030869 RID: 198761 RVA: 0x00BEA1D0 File Offset: 0x00BE83D0
		public bool HasPauseLock()
		{
			return this.PauseLocks.Count > 0;
		}

		// Token: 0x0603086A RID: 198762 RVA: 0x00BEA1E0 File Offset: 0x00BE83E0
		public void AddNormalizeTimeScaleLock(string key, bool refreshImmediately = false)
		{
			this.SetKeyedTimeScaleLock(key, ETimeScaleSourceType.InnerNormalizeTimeScaleLock, 1f, refreshImmediately, false);
			PawnTimeScaleComponent.KeyedTimeScaleLock keyedTimeScaleLock;
			this.NormalizeTimeScaleLocks[key] = (this.KeyedTimeScaleLocks.TryGetValue(key, out keyedTimeScaleLock) ? keyedTimeScaleLock.Handle : -1);
		}

		// Token: 0x0603086B RID: 198763 RVA: 0x00BEA222 File Offset: 0x00BE8422
		public void RemoveNormalizeTimeScaleLock(string key, bool refreshImmediately = false)
		{
			this.ResetKeyedTimeScaleLock(key, refreshImmediately);
			this.NormalizeTimeScaleLocks.Remove(key);
		}

		// Token: 0x0603086C RID: 198764 RVA: 0x00BEA239 File Offset: 0x00BE8439
		public void AddForceTimeScale(float scale, string key, bool refreshImmediately = false, ETimeScaleSourceType sourceType = ETimeScaleSourceType.InnerForceTimeScale)
		{
			this.SetKeyedTimeScaleLock(key, sourceType, scale, refreshImmediately, false);
		}

		// Token: 0x0603086D RID: 198765 RVA: 0x00BEA247 File Offset: 0x00BE8447
		public void RemoveForceTimeScale(string key, bool refreshImmediately = false)
		{
			this.ResetKeyedTimeScaleLock(key, refreshImmediately);
		}

		// Token: 0x0603086E RID: 198766 RVA: 0x00BEA251 File Offset: 0x00BE8451
		public void AddDelayLock(string key)
		{
			this.AddNormalizeTimeScaleLock(key, false);
		}

		// Token: 0x0603086F RID: 198767 RVA: 0x00BEA25B File Offset: 0x00BE845B
		public void RemoveDelayLock(string key)
		{
			this.RemoveNormalizeTimeScaleLock(key, false);
		}

		// Token: 0x06030870 RID: 198768 RVA: 0x00BEA268 File Offset: 0x00BE8468
		public float GetTopForeverTimeScale(ESourceEffectGroup? effectGroup = null)
		{
			ForeverTimeScale topForeverTimeScaleConfig = this.GetTopForeverTimeScaleConfig(effectGroup);
			if (topForeverTimeScaleConfig == null)
			{
				return 1f;
			}
			return topForeverTimeScaleConfig.TimeDilation;
		}

		// Token: 0x06030871 RID: 198769 RVA: 0x00BEA28C File Offset: 0x00BE848C
		[return: Nullable(2)]
		public ForeverTimeScale GetTopForeverTimeScaleByList(PriorityQueue<ForeverTimeScale> list)
		{
			while (!list.Empty)
			{
				ForeverTimeScale top = list.Top;
				if (top == null)
				{
					return null;
				}
				if (!top.MarkDelete)
				{
					return top;
				}
				this.ForeverTimeScaleMap.Remove(top.Id);
				list.Pop();
			}
			return null;
		}

		// Token: 0x06030872 RID: 198770 RVA: 0x00BEA2D4 File Offset: 0x00BE84D4
		[NullableContext(2)]
		public ForeverTimeScale GetTopForeverTimeScaleConfig(ESourceEffectGroup? effectGroup = null)
		{
			if (effectGroup == null)
			{
				ForeverTimeScale topForeverTimeScaleByList = this.GetTopForeverTimeScaleByList(this.ForeverTimeScaleViewOnly);
				ForeverTimeScale topForeverTimeScaleByList2 = this.GetTopForeverTimeScaleByList(this.ForeverTimeScaleLogicView);
				if (topForeverTimeScaleByList == null)
				{
					return topForeverTimeScaleByList2;
				}
				if (topForeverTimeScaleByList2 == null)
				{
					return topForeverTimeScaleByList;
				}
				if (PawnTimeScaleComponent.CompareScalePriority(topForeverTimeScaleByList, topForeverTimeScaleByList2) >= 0)
				{
					return topForeverTimeScaleByList2;
				}
				return topForeverTimeScaleByList;
			}
			else
			{
				if (effectGroup.GetValueOrDefault() == ESourceEffectGroup.ViewOnly)
				{
					return this.GetTopForeverTimeScaleByList(this.ForeverTimeScaleViewOnly);
				}
				return this.GetTopForeverTimeScaleByList(this.ForeverTimeScaleLogicView);
			}
		}

		// Token: 0x06030873 RID: 198771 RVA: 0x00BEA340 File Offset: 0x00BE8540
		public string GetDebugString()
		{
			string text = "";
			if (this.ForeverTimeScaleLogicView.Empty && this.ForeverTimeScaleViewOnly.Empty)
			{
				text += "没有生效的ForeverTimeScale\n";
			}
			else
			{
				ForeverTimeScale topForeverTimeScaleConfig = this.GetTopForeverTimeScaleConfig(new ESourceEffectGroup?(ESourceEffectGroup.LogicAndView));
				if (topForeverTimeScaleConfig != null)
				{
					string str = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(56, 2);
					defaultInterpolatedStringHandler.AppendLiteral("\t生效的LogicAndViewTimeScale: SourceType: ");
					defaultInterpolatedStringHandler.AppendFormatted<ETimeScaleSourceType>(topForeverTimeScaleConfig.SourceType);
					defaultInterpolatedStringHandler.AppendLiteral(", TimeDilation: ");
					defaultInterpolatedStringHandler.AppendFormatted<float>(topForeverTimeScaleConfig.TimeDilation);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					text = str + defaultInterpolatedStringHandler.ToStringAndClear();
				}
				ForeverTimeScale topForeverTimeScaleConfig2 = this.GetTopForeverTimeScaleConfig(new ESourceEffectGroup?(ESourceEffectGroup.ViewOnly));
				if (topForeverTimeScaleConfig2 != null)
				{
					string str2 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 2);
					defaultInterpolatedStringHandler.AppendLiteral("\t生效的ViewOnlyTimeScale: SourceType: ");
					defaultInterpolatedStringHandler.AppendFormatted<ETimeScaleSourceType>(topForeverTimeScaleConfig2.SourceType);
					defaultInterpolatedStringHandler.AppendLiteral(", TimeDilation: ");
					defaultInterpolatedStringHandler.AppendFormatted<float>(topForeverTimeScaleConfig2.TimeDilation);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					text = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
			return text;
		}

		// Token: 0x06030874 RID: 198772 RVA: 0x00BEA44C File Offset: 0x00BE864C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			PawnTimeScaleComponent pawnTimeScaleComponent = (PawnTimeScaleComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (pawnTimeScaleComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("HitComp"))
			{
				if (pawnTimeScaleComponent.HitComp == null)
				{
					this.HitComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterHitComponent>(this.HitComp), "HitComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TimeScaleInternal"))
			{
				this.TimeScaleInternal = pawnTimeScaleComponent.TimeScaleInternal;
			}
			if (base.CanResetComponentProperty("DisableHandle"))
			{
				this.DisableHandle = pawnTimeScaleComponent.DisableHandle;
			}
			if (base.CanResetComponentProperty("FreezeTimeScaleInternal"))
			{
				this.FreezeTimeScaleInternal = pawnTimeScaleComponent.FreezeTimeScaleInternal;
			}
			if (base.CanResetComponentProperty("BulletHitDiscount"))
			{
				this.BulletHitDiscount = pawnTimeScaleComponent.BulletHitDiscount;
			}
			if (base.CanResetComponentProperty("TimeScaleList") && pawnTimeScaleComponent.TimeScaleList != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<PriorityQueue<TimeScale>>(this.TimeScaleList), "TimeScaleList"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TimeScaleMap") && pawnTimeScaleComponent.TimeScaleMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, TimeScale>>(this.TimeScaleMap), "TimeScaleMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TimeScaleId"))
			{
				this.TimeScaleId = pawnTimeScaleComponent.TimeScaleId;
			}
			if (base.CanResetComponentProperty("ForeverTimeScaleLogicView") && pawnTimeScaleComponent.ForeverTimeScaleLogicView != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<PriorityQueue<ForeverTimeScale>>(this.ForeverTimeScaleLogicView), "ForeverTimeScaleLogicView"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ForeverTimeScaleViewOnly") && pawnTimeScaleComponent.ForeverTimeScaleViewOnly != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<PriorityQueue<ForeverTimeScale>>(this.ForeverTimeScaleViewOnly), "ForeverTimeScaleViewOnly"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ForeverTimeScaleMap") && pawnTimeScaleComponent.ForeverTimeScaleMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, ForeverTimeScale>>(this.ForeverTimeScaleMap), "ForeverTimeScaleMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("KeyedTimeScaleLocks") && pawnTimeScaleComponent.KeyedTimeScaleLocks != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, PawnTimeScaleComponent.KeyedTimeScaleLock>>(this.KeyedTimeScaleLocks), "KeyedTimeScaleLocks"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("PauseLocks"))
			{
				if (pawnTimeScaleComponent.PauseLocks == null)
				{
					this.PauseLocks = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, int>>(this.PauseLocks), "PauseLocks"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("NormalizeTimeScaleLocks"))
			{
				if (pawnTimeScaleComponent.NormalizeTimeScaleLocks == null)
				{
					this.NormalizeTimeScaleLocks = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, int>>(this.NormalizeTimeScaleLocks), "NormalizeTimeScaleLocks"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06030875 RID: 198773 RVA: 0x00BEA6E4 File Offset: 0x00BE88E4
		public PawnTimeScaleComponent()
		{
			Comparison<TimeScale> compare;
			if ((compare = PawnTimeScaleComponent.<>O.<0>__CompareScalePriority) == null)
			{
				compare = (PawnTimeScaleComponent.<>O.<0>__CompareScalePriority = new Comparison<TimeScale>(PawnTimeScaleComponent.CompareScalePriority));
			}
			this.TimeScaleList = new PriorityQueue<TimeScale>(compare);
			this.TimeScaleMap = new Dictionary<int, TimeScale>();
			this.TimeScaleId = 1;
			Comparison<ForeverTimeScale> compare2;
			if ((compare2 = PawnTimeScaleComponent.<>O.<1>__CompareScalePriority) == null)
			{
				compare2 = (PawnTimeScaleComponent.<>O.<1>__CompareScalePriority = new Comparison<ForeverTimeScale>(PawnTimeScaleComponent.CompareScalePriority));
			}
			this.ForeverTimeScaleLogicView = new PriorityQueue<ForeverTimeScale>(compare2);
			Comparison<ForeverTimeScale> compare3;
			if ((compare3 = PawnTimeScaleComponent.<>O.<1>__CompareScalePriority) == null)
			{
				compare3 = (PawnTimeScaleComponent.<>O.<1>__CompareScalePriority = new Comparison<ForeverTimeScale>(PawnTimeScaleComponent.CompareScalePriority));
			}
			this.ForeverTimeScaleViewOnly = new PriorityQueue<ForeverTimeScale>(compare3);
			this.ForeverTimeScaleMap = new Dictionary<int, ForeverTimeScale>();
			this.KeyedTimeScaleLocks = new Dictionary<string, PawnTimeScaleComponent.KeyedTimeScaleLock>();
			this.PauseLocks = new Dictionary<string, int>();
			this.NormalizeTimeScaleLocks = new Dictionary<string, int>();
			base..ctor();
		}

		// Token: 0x06030876 RID: 198774 RVA: 0x00BEA7C8 File Offset: 0x00BE89C8
		// Note: this type is marked as 'beforefieldinit'.
		unsafe static PawnTimeScaleComponent()
		{
			Dictionary<ESourceEffectGroup, List<ETimeScaleSourceType>> dictionary = new Dictionary<ESourceEffectGroup, List<ETimeScaleSourceType>>();
			ESourceEffectGroup key = ESourceEffectGroup.LogicAndView;
			int num = 15;
			List<ETimeScaleSourceType> list = new List<ETimeScaleSourceType>(num);
			CollectionsMarshal.SetCount<ETimeScaleSourceType>(list, num);
			Span<ETimeScaleSourceType> span = CollectionsMarshal.AsSpan<ETimeScaleSourceType>(list);
			int num2 = 0;
			*span[num2] = ETimeScaleSourceType.DefaultTimeScale;
			num2++;
			*span[num2] = ETimeScaleSourceType.MyBullet;
			num2++;
			*span[num2] = ETimeScaleSourceType.OthersBullet;
			num2++;
			*span[num2] = ETimeScaleSourceType.Counter;
			num2++;
			*span[num2] = ETimeScaleSourceType.BeCountered;
			num2++;
			*span[num2] = ETimeScaleSourceType.BattleSettlement;
			num2++;
			*span[num2] = ETimeScaleSourceType.Buff;
			num2++;
			*span[num2] = ETimeScaleSourceType.PanelQte;
			num2++;
			*span[num2] = ETimeScaleSourceType.TimeStopMachine;
			num2++;
			*span[num2] = ETimeScaleSourceType.InnerPauseLock;
			num2++;
			*span[num2] = ETimeScaleSourceType.InnerNormalizeTimeScaleLock;
			num2++;
			*span[num2] = ETimeScaleSourceType.InnerForceTimeScale;
			num2++;
			*span[num2] = ETimeScaleSourceType.Portal;
			num2++;
			*span[num2] = ETimeScaleSourceType.DeathEffect;
			num2++;
			*span[num2] = ETimeScaleSourceType.SelfCentered;
			dictionary[key] = list;
			ESourceEffectGroup key2 = ESourceEffectGroup.ViewOnly;
			num2 = 1;
			List<ETimeScaleSourceType> list2 = new List<ETimeScaleSourceType>(num2);
			CollectionsMarshal.SetCount<ETimeScaleSourceType>(list2, num2);
			span = CollectionsMarshal.AsSpan<ETimeScaleSourceType>(list2);
			num = 0;
			*span[num] = ETimeScaleSourceType.SelfBeHit;
			dictionary[key2] = list2;
			PawnTimeScaleComponent.sourceEffectGroup = dictionary;
			Dictionary<ETimeScaleSourceGroup, List<ETimeScaleSourceType>> dictionary2 = new Dictionary<ETimeScaleSourceGroup, List<ETimeScaleSourceType>>();
			ETimeScaleSourceGroup key3 = ETimeScaleSourceGroup.Battle;
			num = 10;
			List<ETimeScaleSourceType> list3 = new List<ETimeScaleSourceType>(num);
			CollectionsMarshal.SetCount<ETimeScaleSourceType>(list3, num);
			span = CollectionsMarshal.AsSpan<ETimeScaleSourceType>(list3);
			num2 = 0;
			*span[num2] = ETimeScaleSourceType.DefaultTimeScale;
			num2++;
			*span[num2] = ETimeScaleSourceType.MyBullet;
			num2++;
			*span[num2] = ETimeScaleSourceType.OthersBullet;
			num2++;
			*span[num2] = ETimeScaleSourceType.Counter;
			num2++;
			*span[num2] = ETimeScaleSourceType.BeCountered;
			num2++;
			*span[num2] = ETimeScaleSourceType.Buff;
			num2++;
			*span[num2] = ETimeScaleSourceType.PanelQte;
			num2++;
			*span[num2] = ETimeScaleSourceType.TimeStopMachine;
			num2++;
			*span[num2] = ETimeScaleSourceType.Portal;
			num2++;
			*span[num2] = ETimeScaleSourceType.DeathEffect;
			dictionary2[key3] = list3;
			ETimeScaleSourceGroup key4 = ETimeScaleSourceGroup.SelfCentered;
			num2 = 1;
			List<ETimeScaleSourceType> list4 = new List<ETimeScaleSourceType>(num2);
			CollectionsMarshal.SetCount<ETimeScaleSourceType>(list4, num2);
			span = CollectionsMarshal.AsSpan<ETimeScaleSourceType>(list4);
			num = 0;
			*span[num] = ETimeScaleSourceType.SelfCentered;
			dictionary2[key4] = list4;
			ETimeScaleSourceGroup key5 = ETimeScaleSourceGroup.AdvancedBattle;
			num = 2;
			List<ETimeScaleSourceType> list5 = new List<ETimeScaleSourceType>(num);
			CollectionsMarshal.SetCount<ETimeScaleSourceType>(list5, num);
			span = CollectionsMarshal.AsSpan<ETimeScaleSourceType>(list5);
			num2 = 0;
			*span[num2] = ETimeScaleSourceType.SelfBeHit;
			num2++;
			*span[num2] = ETimeScaleSourceType.InnerForceTimeScale;
			dictionary2[key5] = list5;
			ETimeScaleSourceGroup key6 = ETimeScaleSourceGroup.ULT;
			num2 = 2;
			List<ETimeScaleSourceType> list6 = new List<ETimeScaleSourceType>(num2);
			CollectionsMarshal.SetCount<ETimeScaleSourceType>(list6, num2);
			span = CollectionsMarshal.AsSpan<ETimeScaleSourceType>(list6);
			num = 0;
			*span[num] = ETimeScaleSourceType.InnerPauseLock;
			num++;
			*span[num] = ETimeScaleSourceType.InnerNormalizeTimeScaleLock;
			dictionary2[key6] = list6;
			ETimeScaleSourceGroup key7 = ETimeScaleSourceGroup.BattleFinish;
			num = 1;
			List<ETimeScaleSourceType> list7 = new List<ETimeScaleSourceType>(num);
			CollectionsMarshal.SetCount<ETimeScaleSourceType>(list7, num);
			span = CollectionsMarshal.AsSpan<ETimeScaleSourceType>(list7);
			num2 = 0;
			*span[num2] = ETimeScaleSourceType.BattleSettlement;
			dictionary2[key7] = list7;
			PawnTimeScaleComponent.sourceTypeGroup = dictionary2;
		}

		// Token: 0x0401BE33 RID: 114227
		private const float LIMIT_SCALE = 0f;

		// Token: 0x0401BE34 RID: 114228
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ESourceEffectGroup, List<ETimeScaleSourceType>> sourceEffectGroup;

		// Token: 0x0401BE35 RID: 114229
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ETimeScaleSourceGroup, List<ETimeScaleSourceType>> sourceTypeGroup;

		// Token: 0x0401BE36 RID: 114230
		[Nullable(2)]
		protected BaseActorComponent ActorComp;

		// Token: 0x0401BE37 RID: 114231
		[Nullable(2)]
		private CharacterHitComponent HitComp;

		// Token: 0x0401BE38 RID: 114232
		protected float TimeScaleInternal = 1f;

		// Token: 0x0401BE39 RID: 114233
		protected int? DisableHandle;

		// Token: 0x0401BE3A RID: 114234
		protected float FreezeTimeScaleInternal = 1f;

		// Token: 0x0401BE3B RID: 114235
		private float BulletHitDiscount = 1f;

		// Token: 0x0401BE3C RID: 114236
		protected readonly PriorityQueue<TimeScale> TimeScaleList;

		// Token: 0x0401BE3D RID: 114237
		protected readonly Dictionary<int, TimeScale> TimeScaleMap;

		// Token: 0x0401BE3E RID: 114238
		private int TimeScaleId;

		// Token: 0x0401BE3F RID: 114239
		protected readonly PriorityQueue<ForeverTimeScale> ForeverTimeScaleLogicView;

		// Token: 0x0401BE40 RID: 114240
		protected readonly PriorityQueue<ForeverTimeScale> ForeverTimeScaleViewOnly;

		// Token: 0x0401BE41 RID: 114241
		protected readonly Dictionary<int, ForeverTimeScale> ForeverTimeScaleMap;

		// Token: 0x0401BE42 RID: 114242
		private readonly Dictionary<string, PawnTimeScaleComponent.KeyedTimeScaleLock> KeyedTimeScaleLocks;

		// Token: 0x0401BE43 RID: 114243
		protected Dictionary<string, int> PauseLocks;

		// Token: 0x0401BE44 RID: 114244
		protected Dictionary<string, int> NormalizeTimeScaleLocks;

		// Token: 0x0200A98B RID: 43403
		[NullableContext(0)]
		private class KeyedTimeScaleLock
		{
			// Token: 0x0403481B RID: 215067
			public int Handle;

			// Token: 0x0403481C RID: 215068
			public float Scale;

			// Token: 0x0403481D RID: 215069
			public ETimeScaleSourceType SourceType;

			// Token: 0x0403481E RID: 215070
			public bool NeedImmuneCheck;
		}

		// Token: 0x0200A98C RID: 43404
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403481F RID: 215071
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<TimeScale> <0>__CompareScalePriority;

			// Token: 0x04034820 RID: 215072
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<ForeverTimeScale> <1>__CompareScalePriority;
		}
	}
}

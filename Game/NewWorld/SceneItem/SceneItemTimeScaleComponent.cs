using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004811 RID: 18449
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemTimeScaleComponent : PawnTimeScaleComponent
	{
		// Token: 0x06030023 RID: 196643 RVA: 0x00B9FC1C File Offset: 0x00B9DE1C
		protected override bool OnInit()
		{
			if (!base.OnInit())
			{
				return false;
			}
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			return true;
		}

		// Token: 0x06030024 RID: 196644 RVA: 0x00B9FC3A File Offset: 0x00B9DE3A
		protected override bool OnStart()
		{
			if (!base.OnStart())
			{
				return false;
			}
			if (this.TimeScaleList.Empty)
			{
				this.SetTimeScaleTicking(false, "[SceneItemTimeScaleComponent] OnStart, 初始关闭时间缩放");
			}
			this.TagComponent = base.Entity.GetComponent<LevelTagComponent>();
			return true;
		}

		// Token: 0x06030025 RID: 196645 RVA: 0x00B9FC74 File Offset: 0x00B9DE74
		public override void SetTimeScaleTicking(bool enable, string reason = null)
		{
			if (enable && this.DisableHandle != null)
			{
				if (base.Enable(new int?(this.DisableHandle.Value), reason ?? "[SceneItemTimeScaleComponent] 开启Tick"))
				{
					this.DisableHandle = null;
					return;
				}
			}
			else if (!enable && this.DisableHandle == null)
			{
				this.DisableHandle = new int?(base.Disable(reason ?? "[SceneItemTimeScaleComponent] 关闭Tick"));
				this.ClearTimeScaleTag();
			}
		}

		// Token: 0x06030026 RID: 196646 RVA: 0x00B9FCF4 File Offset: 0x00B9DEF4
		protected override void OnTick(float delta)
		{
			float num = 1f;
			float num2 = 1f;
			bool flag = false;
			while (!this.TimeScaleList.Empty)
			{
				TimeScale top = this.TimeScaleList.Top;
				if (top == null)
				{
					break;
				}
				if (this.IsTimescaleValid(top, delta))
				{
					num = top.CalculateTimeScale();
					flag = top.NeedAddSceneItemTag;
					if (top.EndTime - top.StartTime >= 0.800000011920929)
					{
						num2 = num;
						break;
					}
					break;
				}
				else
				{
					this.TimeScaleMap.Remove(top.Id);
					this.TimeScaleList.Pop();
				}
			}
			this.FreezeTimeScaleInternal = num;
			float topForeverTimeScale = base.GetTopForeverTimeScale(null);
			num *= topForeverTimeScale;
			num2 *= topForeverTimeScale;
			if (num != this.TimeScaleInternal)
			{
				this.ClearTimeScaleTag();
				if (flag && num != 1f)
				{
					LevelTagComponent tagComponent = this.TagComponent;
					if (tagComponent != null)
					{
						tagComponent.AddTag(new int?((num > 1f) ? SceneItemTimeScaleComponent.upsizeTag : SceneItemTimeScaleComponent.downsizeTag));
					}
				}
				this.TimeScaleInternal = num;
				base.Entity.SetTimeDilation(base.TimeDilation);
			}
			float num3 = num2;
			float timeDilation = base.TimeDilation;
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			num2 = num3 * (timeDilation * ((instance != null) ? instance.SelfCenteredTimeDilation : 1f));
			SceneItemActorComponent component = base.Entity.GetComponent<SceneItemActorComponent>();
			if (component != null)
			{
				component.UpdateAkFinalTimeScale(num2, false);
			}
			if (this.TimeScaleList.Empty)
			{
				this.SetTimeScaleTicking(false, "[PawnTimeScaleComponent] 时间缩放结束");
			}
		}

		// Token: 0x06030027 RID: 196647 RVA: 0x00B9FE53 File Offset: 0x00B9E053
		public override int SetTimeScale(int priority, float timeDilation, UCurveFloat curve, float duration, ETimeScaleSourceType sourceType, bool needAddSceneItemTag = false, bool immuneSelfCenter = false)
		{
			int num = base.SetTimeScale(priority, timeDilation, curve, duration, sourceType, needAddSceneItemTag, false);
			if (num >= 0)
			{
				this.SetTimeScaleTicking(true, null);
			}
			this.OnTick(0f);
			return num;
		}

		// Token: 0x06030028 RID: 196648 RVA: 0x00B9FE7C File Offset: 0x00B9E07C
		public override void RemoveTimeScale(int id)
		{
			base.RemoveTimeScale(id);
			this.OnTick(0f);
		}

		// Token: 0x06030029 RID: 196649 RVA: 0x00B9FE90 File Offset: 0x00B9E090
		public override int SetForeverTimeScale(ETimeScaleSourceType type, float timeScale, int priority = 0, bool refreshImmediately = false)
		{
			int result = base.SetForeverTimeScale(type, timeScale, priority, false);
			this.OnTick(0f);
			return result;
		}

		// Token: 0x0603002A RID: 196650 RVA: 0x00B9FEA7 File Offset: 0x00B9E0A7
		public override void RemoveForeverTimeScale(int id, bool refreshImmediately = false)
		{
			base.RemoveForeverTimeScale(id, false);
			this.OnTick(0f);
		}

		// Token: 0x0603002B RID: 196651 RVA: 0x00B9FEBC File Offset: 0x00B9E0BC
		private void ClearTimeScaleTag()
		{
			if (this.TagComponent != null)
			{
				this.TagComponent.RemoveTag(new int?(SceneItemTimeScaleComponent.downsizeTag));
				this.TagComponent.RemoveTag(new int?(SceneItemTimeScaleComponent.upsizeTag));
			}
		}

		// Token: 0x0603002C RID: 196652 RVA: 0x00B9FEF4 File Offset: 0x00B9E0F4
		protected override void OnChangeTimeDilation(float timeDilation)
		{
			base.OnChangeTimeDilation(timeDilation);
			if (this.CreatureDataComp == null)
			{
				return;
			}
			if (LevelGeneralNetworks.CheckEntityCanPushTimeDilation(this.CreatureDataComp.GetEntityTimeScaleModifyStrategy()))
			{
				float num = base.CurrentTimeScale * timeDilation;
				PawnSelfCenterComponent component = base.Entity.GetComponent<PawnSelfCenterComponent>();
				if (component != null && component.ExtraTimeDilationInSelfCenteredMode != 0f)
				{
					num /= component.ExtraTimeDilationInSelfCenteredMode;
				}
				LevelGeneralNetworks.PushEntityTimeDilation(this.CreatureDataComp.GetCreatureDataId(), num);
			}
		}

		// Token: 0x0603002D RID: 196653 RVA: 0x00B9FF64 File Offset: 0x00B9E164
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemTimeScaleComponent sceneItemTimeScaleComponent = (SceneItemTimeScaleComponent)componentTemplate;
			if (base.CanResetComponentProperty("TagComponent"))
			{
				if (sceneItemTimeScaleComponent.TagComponent == null)
				{
					this.TagComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.TagComponent), "TagComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (sceneItemTimeScaleComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B8E9 RID: 112873
		private static readonly int downsizeTag = GameplayTagDefine.EGameplayTagId["关卡.Common.表现.时间缩放.缩小"];

		// Token: 0x0401B8EA RID: 112874
		private static readonly int upsizeTag = GameplayTagDefine.EGameplayTagId["关卡.Common.表现.时间缩放.放大"];

		// Token: 0x0401B8EB RID: 112875
		private LevelTagComponent TagComponent;

		// Token: 0x0401B8EC RID: 112876
		private CreatureDataComponent CreatureDataComp;
	}
}

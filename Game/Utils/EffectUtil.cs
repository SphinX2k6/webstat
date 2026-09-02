using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046F7 RID: 18167
	[NullableContext(1)]
	[Nullable(0)]
	public class EffectUtil
	{
		// Token: 0x0602F3D7 RID: 193495 RVA: 0x00B33AA4 File Offset: 0x00B31CA4
		public static string GetEffectPath(string effectId)
		{
			return ConfigEffectConfigById.GetConfig(effectId, true).Value.Path;
		}

		// Token: 0x0602F3D8 RID: 193496 RVA: 0x00B33AC8 File Offset: 0x00B31CC8
		public static int? SpawnUiEffect(string effectId, string reason, FTransformDouble? transform = null, [Nullable(2)] EffectContext context = null)
		{
			FTransformDouble valueOrDefault = transform.GetValueOrDefault();
			if (transform == null)
			{
				valueOrDefault = new FTransformDouble();
				transform = new FTransformDouble?(valueOrDefault);
			}
			string effectPath = EffectUtil.GetEffectPath(effectId);
			return new int?(Singleton<EffectSystem>.Instance.SpawnEffect(GlobalData.World, transform, effectPath, reason, null, EEffectType.UiScene3D, null, null, null, false, false));
		}

		// Token: 0x0602F3D9 RID: 193497 RVA: 0x00B33B1B File Offset: 0x00B31D1B
		public static string GetPreviewReplaceEffectPath(string oldPath)
		{
			return oldPath;
		}

		// Token: 0x0602F3DA RID: 193498 RVA: 0x00B33B20 File Offset: 0x00B31D20
		public static void RefreshAdditionTimeScale(int effect, PawnTimeScaleComponent timeScaleComp)
		{
			if (timeScaleComp == null || !timeScaleComp.Valid)
			{
				return;
			}
			ForeverTimeScale topForeverTimeScaleConfig = timeScaleComp.GetTopForeverTimeScaleConfig(new ESourceEffectGroup?(ESourceEffectGroup.LogicAndView));
			if (topForeverTimeScaleConfig == null)
			{
				return;
			}
			Singleton<EffectSystem>.Instance.SetAdditionTimeScale(topForeverTimeScaleConfig.SourceType, effect, topForeverTimeScaleConfig.TimeDilation);
		}

		// Token: 0x0602F3DB RID: 193499 RVA: 0x00B33B68 File Offset: 0x00B31D68
		public static void SetEffectTimeScale(int effect, PawnTimeScaleComponent timeScaleComp, float entityTimeDilation, ETimeScaleType timeScaleType = ETimeScaleType.FollowEntity)
		{
			float freezeTimeScale = timeScaleComp.FreezeTimeScale;
			Singleton<EffectSystem>.Instance.SetTimeScale(effect, freezeTimeScale * entityTimeDilation, true);
			if (timeScaleType == ETimeScaleType.FollowEntity)
			{
				EffectUtil.RefreshAdditionTimeScale(effect, timeScaleComp);
				return;
			}
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			float timeScale = (instance != null) ? instance.InverseSelfCenteredTimeDilation : 1f;
			Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, effect, timeScale);
		}

		// Token: 0x0602F3DC RID: 193500 RVA: 0x00B33BBC File Offset: 0x00B31DBC
		public static void SetAdditionalEffectTimeScaleByEntity(EntityHandle entityHandle, int effectId)
		{
			if (entityHandle == null || !entityHandle.Valid)
			{
				return;
			}
			PawnTimeScaleComponent component = entityHandle.Entity.GetComponent<PawnTimeScaleComponent>();
			if (component == null || !component.Valid)
			{
				return;
			}
			EffectUtil.SetEffectTimeScale(effectId, component, entityHandle.Entity.TimeDilation, ETimeScaleType.FollowEntity);
		}

		// Token: 0x0602F3DD RID: 193501 RVA: 0x00B33C0C File Offset: 0x00B31E0C
		public static void ListenForeverTimeScale(int effect, PawnTimeScaleComponent timeScaleComp)
		{
			EffectUtil.<>c__DisplayClass6_0 CS$<>8__locals1 = new EffectUtil.<>c__DisplayClass6_0();
			CS$<>8__locals1.effect = effect;
			CS$<>8__locals1.timeScaleComp = timeScaleComp;
			CS$<>8__locals1.entity = CS$<>8__locals1.timeScaleComp.Entity;
			Singleton<EventSystem>.Instance.AddWithTarget<ETimeScaleSourceType, float, int>(CS$<>8__locals1.entity, EEventName.OnForeverTimeDilationAdd, new Action<ETimeScaleSourceType, float, int>(CS$<>8__locals1.<ListenForeverTimeScale>g__OnSelfCenteredChanged|0));
			Singleton<EventSystem>.Instance.AddWithTarget<ETimeScaleSourceType, float, int>(CS$<>8__locals1.entity, EEventName.OnForeverTimeDilationRemove, new Action<ETimeScaleSourceType, float, int>(CS$<>8__locals1.<ListenForeverTimeScale>g__OnSelfCenteredChanged|0));
			Singleton<EffectSystem>.Instance.AddFinishCallback(CS$<>8__locals1.effect, delegate(int finishedHandle)
			{
				if (!CS$<>8__locals1.entity.Valid)
				{
					return;
				}
				Singleton<EventSystem>.Instance.RemoveWithTarget<ETimeScaleSourceType, float, int>(CS$<>8__locals1.entity, EEventName.OnForeverTimeDilationAdd, new Action<ETimeScaleSourceType, float, int>(base.<ListenForeverTimeScale>g__OnSelfCenteredChanged|0));
				Singleton<EventSystem>.Instance.RemoveWithTarget<ETimeScaleSourceType, float, int>(CS$<>8__locals1.entity, EEventName.OnForeverTimeDilationRemove, new Action<ETimeScaleSourceType, float, int>(base.<ListenForeverTimeScale>g__OnSelfCenteredChanged|0));
			});
		}
	}
}

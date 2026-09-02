using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067C6 RID: 26566
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardShopPlotPanel : UiPanelBase
	{
		// Token: 0x06042474 RID: 271476 RVA: 0x01100378 File Offset: 0x010FE578
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042475 RID: 271477 RVA: 0x011003E4 File Offset: 0x010FE5E4
		private void PlayPlot()
		{
			FishingNpcPerform fishingNpcPerform = ConfigBase<FishingConfig>.Instance.GetFishingNpcPerform(this.PerformId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), fishingNpcPerform.Title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), fishingNpcPerform.Content, Array.Empty<object>());
		}

		// Token: 0x06042476 RID: 271478 RVA: 0x0110043C File Offset: 0x010FE63C
		private void PlayNpcMontage(string montageName)
		{
			int entityIdByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityIdByPbDataId(this.EntityId);
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityIdByPbDataId);
			if (entityById != null)
			{
				object obj;
				if (entityById == null)
				{
					obj = null;
				}
				else
				{
					WorldEntity entity = entityById.Entity;
					obj = ((entity != null) ? entity.GetComponent<NpcPerformComponent>() : null);
				}
				BaseAnimationComponent baseAnimationComponent;
				if (entityById == null)
				{
					baseAnimationComponent = null;
				}
				else
				{
					WorldEntity entity2 = entityById.Entity;
					baseAnimationComponent = ((entity2 != null) ? entity2.GetComponent<BaseAnimationComponent>() : null);
				}
				BaseAnimationComponent baseAnimationComponent2 = baseAnimationComponent;
				object obj2 = obj;
				if (obj2 == null)
				{
					return;
				}
				obj2.PlayPerformMontage(EPerformMode.Action, new IPlayMontageParam
				{
					MontagePath = ((baseAnimationComponent2 != null) ? baseAnimationComponent2.GetMontageResPathByName(montageName) : null)
				}, null, null, false);
			}
		}

		// Token: 0x06042477 RID: 271479 RVA: 0x011004C1 File Offset: 0x010FE6C1
		private void PlayAudio(string audioEvent)
		{
			Singleton<AudioSystem>.Instance.PostEvent(audioEvent);
		}

		// Token: 0x06042478 RID: 271480 RVA: 0x011004D0 File Offset: 0x010FE6D0
		private void PlayOther()
		{
			double serverTimeStamp = Singleton<Time>.Instance.ServerTimeStamp;
			if (serverTimeStamp - this.LastTimeStamp < 5000.0)
			{
				return;
			}
			this.LastTimeStamp = serverTimeStamp;
			FishingNpcPerform fishingNpcPerform = ConfigBase<FishingConfig>.Instance.GetFishingNpcPerform(this.PerformId);
			this.PlayNpcMontage(fishingNpcPerform.MontagePath);
			this.PlayAudio(fishingNpcPerform.AudioEvent);
		}

		// Token: 0x06042479 RID: 271481 RVA: 0x0110052E File Offset: 0x010FE72E
		private void Refresh()
		{
			this.PlayPlot();
			this.PlayOther();
		}

		// Token: 0x0604247A RID: 271482 RVA: 0x0110053C File Offset: 0x010FE73C
		public void ShowPanel(string performId)
		{
			this.PerformId = performId;
			this.Refresh();
			this.SetActive(true);
		}

		// Token: 0x0604247B RID: 271483 RVA: 0x01100552 File Offset: 0x010FE752
		public void HidePanel()
		{
			this.SetActive(false);
		}

		// Token: 0x04024E79 RID: 151161
		private string PerformId = string.Empty;

		// Token: 0x04024E7A RID: 151162
		public int EntityId;

		// Token: 0x04024E7B RID: 151163
		private double LastTimeStamp;

		// Token: 0x04024E7C RID: 151164
		private const int COOLDOWN_TIME = 5000;

		// Token: 0x0200C80F RID: 51215
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D920 RID: 252192
			public const int Name = 0;

			// Token: 0x0403D921 RID: 252193
			public const int Content = 1;
		}
	}
}

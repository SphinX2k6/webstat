using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BA7 RID: 23463
	[NullableContext(2)]
	[Nullable(0)]
	public class InteractionLongPressHud : UiPanelBase
	{
		// Token: 0x0603B5B8 RID: 243128 RVA: 0x00F08F70 File Offset: 0x00F07170
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B5B9 RID: 243129 RVA: 0x00F08FD9 File Offset: 0x00F071D9
		protected override void OnStart()
		{
			this.ProgressSprite = base.GetSprite(0);
			this.TidContentText = base.GetText(1);
			this.SetActive(false);
		}

		// Token: 0x0603B5BA RID: 243130 RVA: 0x00F08FFC File Offset: 0x00F071FC
		protected override void OnBeforeDestroy()
		{
			this.UnbindEntity();
			this.ProgressSprite = null;
			this.TidContentText = null;
		}

		// Token: 0x0603B5BB RID: 243131 RVA: 0x00F09014 File Offset: 0x00F07214
		public void SetContentTid(string tid)
		{
			if (string.IsNullOrEmpty(tid))
			{
				return;
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(tid, null);
			if (localTextNew != null)
			{
				UUIText tidContentText = this.TidContentText;
				if (tidContentText == null)
				{
					return;
				}
				tidContentText.SetText(localTextNew, true);
			}
		}

		// Token: 0x0603B5BC RID: 243132 RVA: 0x00F09047 File Offset: 0x00F07247
		public void SetStartProgress(float? startProgress)
		{
			this.StartProgress = startProgress;
		}

		// Token: 0x0603B5BD RID: 243133 RVA: 0x00F09050 File Offset: 0x00F07250
		public void BindEntity(Entity entity)
		{
			if (this.BoundEntity == entity)
			{
				return;
			}
			this.UnbindEntity();
			if (entity == null || !entity.Valid)
			{
				return;
			}
			this.BoundEntity = entity;
			Singleton<EventSystem>.Instance.AddWithTarget<float>(entity, EEventName.OnInteractionLongPressProgressChange, new Action<float>(this.OnInteractionLongPressProgressChange));
			UUISprite progressSprite = this.ProgressSprite;
			if (progressSprite != null)
			{
				progressSprite.SetFillAmount(0f);
			}
			this.SetActive(this.StartProgress == null);
		}

		// Token: 0x0603B5BE RID: 243134 RVA: 0x00F090D0 File Offset: 0x00F072D0
		public void UnbindEntity()
		{
			if (this.BoundEntity != null)
			{
				if (Singleton<EventSystem>.Instance.HasWithTarget(this.BoundEntity, EEventName.OnInteractionLongPressProgressChange, new Action<float>(this.OnInteractionLongPressProgressChange)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(this.BoundEntity, EEventName.OnInteractionLongPressProgressChange, new Action<float>(this.OnInteractionLongPressProgressChange));
				}
				this.BoundEntity = null;
			}
			this.SetActive(false);
		}

		// Token: 0x0603B5BF RID: 243135 RVA: 0x00F09138 File Offset: 0x00F07338
		private void OnInteractionLongPressProgressChange(float progress)
		{
			if (this.StartProgress != null && progress < this.StartProgress.Value)
			{
				this.SetActive(false);
				return;
			}
			this.SetActive(true);
			UUISprite progressSprite = this.ProgressSprite;
			if (progressSprite == null)
			{
				return;
			}
			progressSprite.SetFillAmount(progress);
		}

		// Token: 0x04021733 RID: 137011
		private UUISprite ProgressSprite;

		// Token: 0x04021734 RID: 137012
		private UUIText TidContentText;

		// Token: 0x04021735 RID: 137013
		private Entity BoundEntity;

		// Token: 0x04021736 RID: 137014
		private float? StartProgress;

		// Token: 0x0200BBDF RID: 48095
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039F76 RID: 237430
			public const int ProgressSprite = 0;

			// Token: 0x04039F77 RID: 237431
			public const int TidContentText = 1;
		}
	}
}

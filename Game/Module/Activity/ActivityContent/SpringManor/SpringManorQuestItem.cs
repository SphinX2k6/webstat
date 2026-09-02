using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006329 RID: 25385
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorQuestItem : GridProxyAbstract<int>
	{
		// Token: 0x0603FC6D RID: 261229 RVA: 0x0105A128 File Offset: 0x01058328
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FC6E RID: 261230 RVA: 0x0105A294 File Offset: 0x01058494
		private void OnToggleClicked(EToggleState state)
		{
			Action<int, int> toggleClickCallback = this.ToggleClickCallback;
			if (toggleClickCallback != null)
			{
				toggleClickCallback(base.GridIndex, this.QuestId);
			}
			this.RefreshRedDot();
		}

		// Token: 0x0603FC6F RID: 261231 RVA: 0x0105A2B9 File Offset: 0x010584B9
		public override void Refresh(int questId, bool isSelected, int gridIndex)
		{
			this.UpdateItem(questId);
		}

		// Token: 0x0603FC70 RID: 261232 RVA: 0x0105A2C2 File Offset: 0x010584C2
		public void RefreshWithoutData()
		{
			this.UpdateItem(this.QuestId);
		}

		// Token: 0x0603FC71 RID: 261233 RVA: 0x0105A2D0 File Offset: 0x010584D0
		public void RefreshRedPoint(bool show)
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(show);
		}

		// Token: 0x0603FC72 RID: 261234 RVA: 0x0105A2E4 File Offset: 0x010584E4
		public void UpdateItem(int inQuestId)
		{
			this.QuestId = inQuestId;
			this.UpdateTrackIconActive();
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.QuestId);
			if (quest == null)
			{
				this.RefreshLockState();
				return;
			}
			this.SetLockIcon();
			this.SetTrackIcon(quest);
			this.UpdateQuestName(quest);
			this.UpdateDistance(this.QuestId);
			this.RefreshRedDot();
		}

		// Token: 0x0603FC73 RID: 261235 RVA: 0x0105A340 File Offset: 0x01058540
		public void RefreshRedDot()
		{
			UUIItem item = base.GetItem(1);
			if (!ModelBase<SpringManorModel>.Instance.IsSubQuest(this.QuestId))
			{
				if (item != null)
				{
					item.SetUIActive(false);
				}
				return;
			}
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			bool? flag = (instance != null) ? new bool?(instance.ActivityData.HasSubQuestRedDot(this.QuestId)) : null;
			if (item != null)
			{
				item.SetUIActive(flag.GetValueOrDefault());
			}
		}

		// Token: 0x0603FC74 RID: 261236 RVA: 0x0105A3AC File Offset: 0x010585AC
		private void RefreshLockState()
		{
			IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(this.QuestId);
			UUISprite sprite = base.GetSprite(2);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.ShowTextNew(questConfig.TidName);
			}
			UUIText text2 = base.GetText(6);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(false);
		}

		// Token: 0x0603FC75 RID: 261237 RVA: 0x0105A41C File Offset: 0x0105861C
		private void SetLockIcon()
		{
			string questLockIconPath = ModelBase<QuestNewModel>.Instance.GetQuestLockIconPath(this.QuestId);
			UUISprite sprite = base.GetSprite(2);
			if (StringUtils.IsEmpty(questLockIconPath))
			{
				sprite.SetUIActive(false);
				return;
			}
			if (ModelBase<SpringManorModel>.Instance.IsCurrentTrackQuest(this.QuestId))
			{
				sprite.SetUIActive(false);
				return;
			}
			this.SetSpriteByPath(questLockIconPath, sprite, true, null, null);
			sprite.SetUIActive(true);
		}

		// Token: 0x0603FC76 RID: 261238 RVA: 0x0105A488 File Offset: 0x01058688
		private void SetTrackIcon(global::Quest quest)
		{
			this.SetSpriteByPath(ConfigBase<QuestNewConfig>.Instance.GetQuestTypeMark(quest.QuestMarkId), base.GetSprite(4), false, null, null);
		}

		// Token: 0x0603FC77 RID: 261239 RVA: 0x0105A4BD File Offset: 0x010586BD
		public void UpdateTrackIconActive()
		{
			base.GetSprite(4).SetUIActive(ModelBase<SpringManorModel>.Instance.IsCurrentTrackQuest(this.QuestId));
		}

		// Token: 0x0603FC78 RID: 261240 RVA: 0x0105A4DB File Offset: 0x010586DB
		private void UpdateQuestName(global::Quest quest)
		{
			base.GetText(5).SetText(quest.Name, true);
		}

		// Token: 0x0603FC79 RID: 261241 RVA: 0x0105A4F0 File Offset: 0x010586F0
		private void UpdateDistance(int questId)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			bool flag = instance.IsSubQuest(questId);
			bool flag2 = instance.IsCurrentTrackQuest(questId);
			UUIText text = base.GetText(6);
			if (flag && !flag2)
			{
				text.SetUIActive(false);
				return;
			}
			string questTrackDistanceText = instance.GetQuestTrackDistanceText(questId);
			text.SetUIActive(questTrackDistanceText != null);
			if (questTrackDistanceText != null)
			{
				text.SetText(questTrackDistanceText, true);
			}
		}

		// Token: 0x0603FC7A RID: 261242 RVA: 0x0105A54A File Offset: 0x0105874A
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleSelect(false, false);
		}

		// Token: 0x0603FC7B RID: 261243 RVA: 0x0105A554 File Offset: 0x01058754
		public void SetToggleSelect(bool select, bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(select ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x04023CEC RID: 146668
		private int QuestId;

		// Token: 0x04023CED RID: 146669
		[Nullable(2)]
		public Action<int, int> ToggleClickCallback;
	}
}

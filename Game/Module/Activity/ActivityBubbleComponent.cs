using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061D3 RID: 25043
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityBubbleComponent
	{
		// Token: 0x0603F30D RID: 258829 RVA: 0x01038E02 File Offset: 0x01037002
		public ActivityBubbleComponent(UUIItem bubbleRootItem, UUISprite bubbleSprite, UUIText bubbleText, Action<string, UUISprite, bool> setSpriteDelegate)
		{
			this.BubbleRootItem = bubbleRootItem;
			this.BubbleSprite = bubbleSprite;
			this.BubbleText = bubbleText;
			this.SetSpriteDelegate = setSpriteDelegate;
		}

		// Token: 0x0603F30E RID: 258830 RVA: 0x01038E28 File Offset: 0x01037028
		public bool RefreshBubble(ActivityBaseData data)
		{
			this.Data = data;
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			if (data.RedPointShowState)
			{
				this.HideBubble();
				return false;
			}
			data.UpdateImportantBubble();
			if (!data.IsShowImportantBubble || data.BubbleType == EActivityBubbleType.None)
			{
				this.HideBubble();
				return false;
			}
			if (data.BubbleType != EActivityBubbleType.Important && instance.CheckBubbleHasClicked(data.Id, data.BubbleType))
			{
				this.HideBubble();
				return false;
			}
			string resourceId;
			if (!ActivityBubbleComponent.BubbleTypeToResourcePathMap.TryGetValue(data.BubbleType, out resourceId))
			{
				this.HideBubble();
				return false;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (string.IsNullOrEmpty(resourcePath))
			{
				this.HideBubble();
				return false;
			}
			this.ShowBubble();
			this.SetSpriteDelegate(resourcePath, this.BubbleSprite, false);
			string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat7(this.GetRemainTime(data.BubbleEndShowTime)).CountDownText;
			if (!string.IsNullOrEmpty(countDownText))
			{
				this.BubbleText.SetText(countDownText, true);
			}
			return true;
		}

		// Token: 0x0603F30F RID: 258831 RVA: 0x01038F1D File Offset: 0x0103711D
		public void ShowBubble()
		{
			this.IsShowBubble = true;
			this.BubbleRootItem.SetUIActive(true);
		}

		// Token: 0x0603F310 RID: 258832 RVA: 0x01038F32 File Offset: 0x01037132
		public void HideBubble()
		{
			this.IsShowBubble = false;
			this.BubbleRootItem.SetUIActive(false);
		}

		// Token: 0x0603F311 RID: 258833 RVA: 0x01038F48 File Offset: 0x01037148
		public bool CheckToUpdateBubbleClickState()
		{
			if (this.IsShowBubble)
			{
				ActivityBaseData data = this.Data;
				if (data == null || data.BubbleType > EActivityBubbleType.None)
				{
					bool flag = ModelBase<ActivityModel>.Instance.CheckBubbleHasClicked(this.Data.Id, this.Data.BubbleType);
					ModelBase<ActivityModel>.Instance.SetBubbleHasClicked(this.Data.Id, this.Data.BubbleType);
					bool flag2 = ModelBase<ActivityModel>.Instance.CheckBubbleHasClicked(this.Data.Id, this.Data.BubbleType);
					return flag != flag2;
				}
			}
			return false;
		}

		// Token: 0x0603F312 RID: 258834 RVA: 0x01038FDD File Offset: 0x010371DD
		public bool GetIsShowBubble()
		{
			return this.IsShowBubble;
		}

		// Token: 0x0603F313 RID: 258835 RVA: 0x01038FE8 File Offset: 0x010371E8
		private double GetRemainTime(long endTime)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return Math.Max((double)endTime - serverTime, 1.0);
		}

		// Token: 0x040237D8 RID: 145368
		[Nullable(2)]
		private ActivityBaseData Data;

		// Token: 0x040237D9 RID: 145369
		private bool IsShowBubble;

		// Token: 0x040237DA RID: 145370
		private static readonly IReadOnlyDictionary<EActivityBubbleType, string> BubbleTypeToResourcePathMap = new Dictionary<EActivityBubbleType, string>
		{
			{
				EActivityBubbleType.Normal,
				"WhiteTimeIcon"
			},
			{
				EActivityBubbleType.Remind,
				"YellowTimeIcon"
			},
			{
				EActivityBubbleType.Important,
				"RedTimeIcon"
			}
		};

		// Token: 0x040237DB RID: 145371
		private UUIItem BubbleRootItem;

		// Token: 0x040237DC RID: 145372
		private UUISprite BubbleSprite;

		// Token: 0x040237DD RID: 145373
		private UUIText BubbleText;

		// Token: 0x040237DE RID: 145374
		private Action<string, UUISprite, bool> SetSpriteDelegate;
	}
}

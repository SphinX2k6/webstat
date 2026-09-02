using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C7C RID: 19580
	[NullableContext(1)]
	[Nullable(0)]
	public class UiComponentUtil
	{
		// Token: 0x06033072 RID: 209010 RVA: 0x00CC7C88 File Offset: 0x00CC5E88
		[return: Nullable(2)]
		public static CSharpScript.Game.Module.RoleUi.StarItem SetStarActiveNew(CSharpScript.Game.Module.RoleUi.StarItem[] starList, int currentCount, int? maxCount = null, bool showNextStar = true)
		{
			int num = starList.Length;
			int valueOrDefault = maxCount.GetValueOrDefault(num);
			CSharpScript.Game.Module.RoleUi.StarItem result = null;
			for (int i = 0; i < num; i++)
			{
				CSharpScript.Game.Module.RoleUi.StarItem starItem = starList[i];
				starItem.SetActive(i + 1 <= valueOrDefault);
				if (i + 1 <= valueOrDefault)
				{
					starItem.SetImgStarOnActive(i < currentCount);
					if (showNextStar)
					{
						starItem.SetImgStarNextActive(i == currentCount);
						if (i == currentCount)
						{
							result = starItem;
						}
						starItem.SetImgStarOffActive(i > currentCount);
					}
					else
					{
						starItem.SetImgStarNextActive(false);
						starItem.SetImgStarOffActive(i >= currentCount);
						if (i == currentCount - 1)
						{
							result = starItem;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06033073 RID: 209011 RVA: 0x00CC7D18 File Offset: 0x00CC5F18
		public static bool SetMoneyState(UUIText costText, UUIText ownText, int costNumber, int ownNumber)
		{
			costText.SetText(costNumber.ToString(), true);
			bool flag = ownNumber >= costNumber;
			ownText.SetText(ownNumber.ToString(), true);
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(ownText.changeColor);
			ownText.SetChangeColor(bUseChangeColor, fcolor);
			costText.useChangeColor = !flag;
			return flag;
		}

		// Token: 0x06033074 RID: 209012 RVA: 0x00CC7D6C File Offset: 0x00CC5F6C
		public static void BindAudioEvent(UUISelectableComponent selectable)
		{
			UUIButtonComponent uuibuttonComponent = selectable as UUIButtonComponent;
			if (uuibuttonComponent != null)
			{
				uuibuttonComponent.OnPostAudioStateEvent.Bind(delegate(EButtonAudioStateTransferType state, string eventPath)
				{
					Singleton<AudioController>.Instance.PostSelectableAudioEvent(eventPath, selectable.GetOwner());
				});
				return;
			}
			UUIExtendToggle uuiextendToggle = selectable as UUIExtendToggle;
			if (uuiextendToggle != null)
			{
				uuiextendToggle.OnPostAudioStateEvent.Bind(delegate(EToggleAudioTransitionState state, string eventPath)
				{
					Singleton<AudioController>.Instance.PostSelectableAudioEvent(eventPath, selectable.GetOwner());
				});
			}
		}

		// Token: 0x06033075 RID: 209013 RVA: 0x00CC7DD3 File Offset: 0x00CC5FD3
		public static void UnBindAudioEventByName(string name)
		{
			Singleton<AudioController>.Instance.StopSelectableAudioEventByName(name);
		}

		// Token: 0x06033076 RID: 209014 RVA: 0x00CC7DE0 File Offset: 0x00CC5FE0
		public static void UnBindAudioEvent(UUISelectableComponent selectable)
		{
			Singleton<AudioController>.Instance.StopSelectableAudioEvent(selectable.GetOwner());
		}
	}
}

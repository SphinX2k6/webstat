using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006327 RID: 25383
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SpringManorBrochureItem : GridProxyAbstract<BrochureItemData>
	{
		// Token: 0x0603FC61 RID: 261217 RVA: 0x01059CB4 File Offset: 0x01057EB4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClick)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickGetButton))
			};
		}

		// Token: 0x0603FC62 RID: 261218 RVA: 0x01059D8B File Offset: 0x01057F8B
		protected override void OnStart()
		{
			AUIBaseActor rootActor = this.RootActor;
			if (rootActor != null)
			{
				rootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
			}
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603FC63 RID: 261219 RVA: 0x01059DC0 File Offset: 0x01057FC0
		[NullableContext(1)]
		private void OnPlaySequenceEvent(string sequenceName, string eventName)
		{
			if (eventName == "Sequence_Brochure_Unlock" && this.Data != null)
			{
				this.Refresh(this.Data, false, 0);
			}
		}

		// Token: 0x0603FC64 RID: 261220 RVA: 0x01059DE5 File Offset: 0x01057FE5
		private void OnClick()
		{
			if (this.OnToggleCallBack != null)
			{
				this.OnToggleCallBack(this.Data);
			}
		}

		// Token: 0x0603FC65 RID: 261221 RVA: 0x01059E00 File Offset: 0x01058000
		private void OnClickGetButton()
		{
			if (this.OnClickGetButtonCallBack != null)
			{
				this.OnClickGetButtonCallBack(this.Data);
			}
		}

		// Token: 0x0603FC66 RID: 261222 RVA: 0x01059E1B File Offset: 0x0105801B
		public void SetToggleCallBack([Nullable(new byte[]
		{
			1,
			2
		})] Action<BrochureItemData> callBack)
		{
			this.OnToggleCallBack = callBack;
		}

		// Token: 0x0603FC67 RID: 261223 RVA: 0x01059E24 File Offset: 0x01058024
		public void SetClickGetButtonCallBack([Nullable(new byte[]
		{
			1,
			2
		})] Action<BrochureItemData> callBack)
		{
			this.OnClickGetButtonCallBack = callBack;
		}

		// Token: 0x0603FC68 RID: 261224 RVA: 0x01059E30 File Offset: 0x01058030
		[NullableContext(1)]
		public override void Refresh(BrochureItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			EBrochureState ebrochureState = data.State;
			if (ebrochureState == EBrochureState.Unlock && this.IsNeedPlayUnlockSequence(this.Data.ConfigId))
			{
				ebrochureState = EBrochureState.Lock;
			}
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			BookItem? bookItem = (instance != null) ? instance.GetSpringManorBookItemById(data.ConfigId) : null;
			if (bookItem == null)
			{
				return;
			}
			bool flag = ebrochureState == EBrochureState.Lock;
			string path = flag ? bookItem.Value.LockIcon : bookItem.Value.UnlockIcon;
			base.TrySetTextureByPath(path, base.GetTexture(1), null, null);
			if (this.TextureTransitionComp == null)
			{
				this.TextureTransitionComp = (base.GetTexture(1).GetOwner().GetComponentByClass(UUITextureTransitionComponent.StaticClass()) as UUITextureTransitionComponent);
			}
			base.SetTextureTransitionByPath(path, this.TextureTransitionComp, EUISelectableSelectionState.EUISelectableSelectionState_MAX);
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIButtonComponent button = base.GetButton(3);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(ebrochureState == EBrochureState.Unlock);
				}
			}
			if (flag)
			{
				bool flag2 = !string.IsNullOrEmpty(bookItem.Value.GuideTitle);
				UUIText text = base.GetText(5);
				if (text != null)
				{
					text.ShowTextNew(flag2 ? bookItem.Value.GuideTitle : bookItem.Value.DescriptionTitle);
				}
			}
			else
			{
				UUIText text2 = base.GetText(5);
				if (text2 != null)
				{
					text2.ShowTextNew(bookItem.Value.DescriptionTitle);
				}
			}
			UiResourceConfig instance2 = ConfigBase<UiResourceConfig>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("SP_BrochureSort0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Index + 1);
			string resourcePath = instance2.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
			this.SetSpriteByPath(resourcePath, base.GetSprite(4), false, null, null);
			this.PlayRewardSequence(ebrochureState == EBrochureState.Unlock);
		}

		// Token: 0x0603FC69 RID: 261225 RVA: 0x0105A024 File Offset: 0x01058224
		private void PlayRewardSequence(bool isPlay)
		{
			if (isPlay)
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.PlayLevelSequenceByName("Gift_Loop", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
				if (sequencePlayer2 == null)
				{
					return;
				}
				sequencePlayer2.StopSequenceByKey("Gift_Loop", false, false);
				return;
			}
		}

		// Token: 0x0603FC6A RID: 261226 RVA: 0x0105A06C File Offset: 0x0105826C
		private bool IsNeedPlayUnlockSequence(int configId)
		{
			HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.SpringManorBrochureUnlockSequencePlayed, null);
			return player == null || !player.Contains(configId);
		}

		// Token: 0x0603FC6B RID: 261227 RVA: 0x0105A094 File Offset: 0x01058294
		public void CheckPlayUnlockSequence()
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.State == EBrochureState.Unlock)
			{
				HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.SpringManorBrochureUnlockSequencePlayed, null) ?? new HashSet<int>();
				if (!hashSet.Contains(this.Data.ConfigId))
				{
					hashSet.Add(this.Data.ConfigId);
					LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.SpringManorBrochureUnlockSequencePlayed, hashSet);
					LevelSequencePlayer sequencePlayer = this.SequencePlayer;
					if (sequencePlayer == null)
					{
						return;
					}
					sequencePlayer.PlayLevelSequenceByName("Unlock", false, null, false);
				}
			}
		}

		// Token: 0x04023CDE RID: 146654
		private Action<BrochureItemData> OnToggleCallBack;

		// Token: 0x04023CDF RID: 146655
		private Action<BrochureItemData> OnClickGetButtonCallBack;

		// Token: 0x04023CE0 RID: 146656
		private BrochureItemData Data;

		// Token: 0x04023CE1 RID: 146657
		private UUITextureTransitionComponent TextureTransitionComp;

		// Token: 0x04023CE2 RID: 146658
		private LevelSequencePlayer SequencePlayer;
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FF5 RID: 24565
	[NullableContext(2)]
	[Nullable(0)]
	public class BuffItem : BuffItemBase
	{
		// Token: 0x0603DDD7 RID: 253399 RVA: 0x00FC6070 File Offset: 0x00FC4270
		[NullableContext(1)]
		public BuffItem(USceneComponent parentItem)
		{
			AActor buffItem = ControllerBase<BattleUiControl>.Instance.Pool.GetBuffItem(parentItem);
			base.CreateThenShowByActor(buffItem, null);
		}

		// Token: 0x0603DDD8 RID: 253400 RVA: 0x00FC60B4 File Offset: 0x00FC42B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DDD9 RID: 253401 RVA: 0x00FC62D4 File Offset: 0x00FC44D4
		protected override void OnStart()
		{
			this.BuffTexture = base.GetTexture(1);
			this.LargeBuffTexture = base.GetTexture(10);
			this.NumText = base.GetText(3);
			this.BarSprite = base.GetSprite(2);
			this.BgSprite = base.GetSprite(9);
			this.BarRoundSprite = base.GetSprite(12);
			this.BgRoundSprite = base.GetSprite(11);
			this.ColorfulFrame = base.GetItem(14);
			this.InitTweenAnim(BuffItem.EChildType.AnimStart);
			this.InitTweenAnim(BuffItem.EChildType.AnimClose);
			this.InitTweenAnim(BuffItem.EChildType.AnimFade);
			this.InitTweenAnim(BuffItem.EChildType.AnimAddBuff);
		}

		// Token: 0x0603DDDA RID: 253402 RVA: 0x00FC636C File Offset: 0x00FC456C
		public override void Activate(GameplayCue buffCueConfig, IActiveBuff buff, bool playAnim = false, int buffNum = 0)
		{
			this.Buff = buff;
			int parametersLength = buffCueConfig.ParametersLength;
			int iconType = 0;
			if (parametersLength > 3 && buffCueConfig.Parameters(3).Length != 0)
			{
				iconType = int.Parse(buffCueConfig.Parameters(3));
			}
			this.SetIcon(buffCueConfig.Path, iconType, buff == null);
			if (buff != null)
			{
				this.SetNum(buff.StackCount);
				if (buff.Duration <= 0f || this.AlwaysFullPercent)
				{
					this.SetPercent(1f);
				}
				else
				{
					this.SetPercent(buff.GetRemainDuration() / buff.Duration);
				}
			}
			else if (buffNum > 1)
			{
				this.SetNum(buffNum);
				this.SetPercent(1f);
			}
			else
			{
				this.SetNum(1);
				this.SetPercent(1f);
			}
			string a = null;
			if (parametersLength > 0)
			{
				a = buffCueConfig.Parameters(0);
			}
			UUISprite sprite = base.GetSprite(8);
			if (sprite != null)
			{
				sprite.SetUIActive(a == "1");
			}
			UUISprite sprite2 = base.GetSprite(4);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(a == "2");
			}
			if (parametersLength > 1 && buffCueConfig.Parameters(1).Length != 0)
			{
				this.SetBarColor(buffCueConfig.Parameters(1));
			}
			else
			{
				this.SetBarColor(null);
			}
			if (parametersLength > 2 && buffCueConfig.Parameters(2).Length != 0)
			{
				this.SetIconColor(buffCueConfig.Parameters(2));
			}
			else
			{
				this.SetIconColor(null);
			}
			base.SetUiActive(true);
			this.StopTweenAnim(BuffItem.EChildType.AnimClose);
			if (playAnim)
			{
				this.PlayTweenAnim(BuffItem.EChildType.AnimStart);
				return;
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAlpha(1f);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 == null)
			{
				return;
			}
			rootItem2.SetUIItemScale(global::Vector.OneVector);
		}

		// Token: 0x0603DDDB RID: 253403 RVA: 0x00FC6510 File Offset: 0x00FC4710
		public void ActivateExceedTip()
		{
			this.BuffTexture.SetUIActive(false);
			this.LargeBuffTexture.SetUIActive(false);
			this.NumText.SetText(string.Empty, true);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconpropertyEllipses_UI");
			this.SetIcon(resourcePath, -1, false);
			UUISprite curBarSprite = this.CurBarSprite;
			if (curBarSprite == null)
			{
				return;
			}
			curBarSprite.SetFillAmount(0f);
		}

		// Token: 0x0603DDDC RID: 253404 RVA: 0x00FC6574 File Offset: 0x00FC4774
		[NullableContext(1)]
		private void SetIcon(string iconPath, int iconType, bool bMergeBuffItem)
		{
			if (this.IconPath == iconPath && this.IconType == iconType && this.MergeBuffItem == bMergeBuffItem)
			{
				return;
			}
			this.IconPath = iconPath;
			this.IconType = iconType;
			this.MergeBuffItem = bMergeBuffItem;
			bool flag = iconType == 3 || iconType == 4;
			this.AlwaysFullPercent = (iconType == 2 || iconType == 4);
			this.ColorfulFrame.SetUIActive(flag);
			this.BuffTexture.SetUIActive(false);
			this.LargeBuffTexture.SetUIActive(false);
			if (iconType == 1)
			{
				this.BgSprite.SetUIActive(false);
				this.BarSprite.SetUIActive(false);
				this.BgRoundSprite.SetUIActive(false);
				this.BarRoundSprite.SetUIActive(false);
				base.SetTextureByPath(iconPath, this.LargeBuffTexture, null, delegate(bool result)
				{
					if (result)
					{
						UUITexture largeBuffTexture = this.LargeBuffTexture;
						if (largeBuffTexture == null)
						{
							return;
						}
						largeBuffTexture.SetUIActive(true);
					}
				});
				return;
			}
			bool flag2 = flag;
			this.BgSprite.SetUIActive(!bMergeBuffItem && !flag2);
			this.BarSprite.SetUIActive(!bMergeBuffItem);
			this.BgRoundSprite.SetUIActive(bMergeBuffItem && !flag2);
			this.BarRoundSprite.SetUIActive(bMergeBuffItem);
			base.SetTextureByPath(iconPath, this.BuffTexture, null, delegate(bool result)
			{
				if (result)
				{
					UUITexture buffTexture = this.BuffTexture;
					if (buffTexture == null)
					{
						return;
					}
					buffTexture.SetUIActive(true);
				}
			});
			this.CurBarSprite = (bMergeBuffItem ? this.BarRoundSprite : this.BarSprite);
			this.Percent = -1f;
		}

		// Token: 0x0603DDDD RID: 253405 RVA: 0x00FC66DC File Offset: 0x00FC48DC
		public override void SetNum(int num)
		{
			if (num == this.Num)
			{
				return;
			}
			if (num > this.Num && this.Num > 0)
			{
				this.PlayTweenAnim(BuffItem.EChildType.AnimStart);
			}
			this.Num = num;
			this.NumText.SetText((num <= 1) ? string.Empty : num.ToString(), true);
		}

		// Token: 0x0603DDDE RID: 253406 RVA: 0x00FC6731 File Offset: 0x00FC4931
		private void SetPercent(float percent)
		{
			if (percent == this.Percent)
			{
				return;
			}
			this.Percent = percent;
			UUISprite curBarSprite = this.CurBarSprite;
			if (curBarSprite != null)
			{
				curBarSprite.SetFillAmount(percent);
			}
			this.PlayFadeAnim(percent <= 0.2f);
		}

		// Token: 0x0603DDDF RID: 253407 RVA: 0x00FC6767 File Offset: 0x00FC4967
		private void PlayFadeAnim(bool bPlay)
		{
			if (this.IsPlayingFadeAnim != bPlay)
			{
				this.IsPlayingFadeAnim = bPlay;
				if (bPlay)
				{
					this.PlayTweenAnim(BuffItem.EChildType.AnimFade);
					return;
				}
				this.StopTweenAnim(BuffItem.EChildType.AnimFade);
				UUIItem item = base.GetItem(0);
				if (item == null)
				{
					return;
				}
				item.SetAlpha(1f);
			}
		}

		// Token: 0x0603DDE0 RID: 253408 RVA: 0x00FC67A4 File Offset: 0x00FC49A4
		private void SetBarColor(string colorStr = null)
		{
			if (!string.IsNullOrEmpty(colorStr))
			{
				UUISprite curBarSprite = this.CurBarSprite;
				if (curBarSprite == null)
				{
					return;
				}
				curBarSprite.SetColor(FColor.FromHex(colorStr));
				return;
			}
			else
			{
				FColor value = this.DefaultBarColor.GetValueOrDefault();
				if (this.DefaultBarColor == null)
				{
					value = FColor.FromHex("FFFFFF7F");
					this.DefaultBarColor = new FColor?(value);
				}
				UUISprite curBarSprite2 = this.CurBarSprite;
				if (curBarSprite2 == null)
				{
					return;
				}
				curBarSprite2.SetColor(this.DefaultBarColor.Value);
				return;
			}
		}

		// Token: 0x0603DDE1 RID: 253409 RVA: 0x00FC681B File Offset: 0x00FC4A1B
		private void SetIconColor(string colorStr = null)
		{
			if (colorStr == this.IconColorStr)
			{
				return;
			}
			this.IconColorStr = colorStr;
			this.BuffTexture.SetColor((!string.IsNullOrEmpty(colorStr)) ? FColor.FromHex(colorStr) : ColorUtils.ColorWhile);
		}

		// Token: 0x0603DDE2 RID: 253410 RVA: 0x00FC6854 File Offset: 0x00FC4A54
		public override void Tick(float delta)
		{
			if (this.Buff == null)
			{
				return;
			}
			if (this.Buff.Duration > 0f && !this.AlwaysFullPercent)
			{
				this.SetPercent(this.Buff.GetRemainDuration() / this.Buff.Duration);
			}
			this.SetNum(this.Buff.StackCount);
		}

		// Token: 0x0603DDE3 RID: 253411 RVA: 0x00FC68B2 File Offset: 0x00FC4AB2
		public override bool TickHiding(float delta)
		{
			if (this.AnimCloseEndTime > Singleton<Time>.Instance.Now)
			{
				return true;
			}
			this.StopTweenAnim(BuffItem.EChildType.AnimClose);
			base.SetUiActive(false);
			return false;
		}

		// Token: 0x0603DDE4 RID: 253412 RVA: 0x00FC68D7 File Offset: 0x00FC4AD7
		public override void Deactivate()
		{
			this.StopTweenAnim(BuffItem.EChildType.AnimStart);
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIItemScale(global::Vector.OneVector);
			}
			this.StopTweenAnim(BuffItem.EChildType.AnimClose);
			this.PlayFadeAnim(false);
			base.SetUiActive(false);
		}

		// Token: 0x0603DDE5 RID: 253413 RVA: 0x00FC690C File Offset: 0x00FC4B0C
		public override void DeactivateWithCloseAnim()
		{
			this.StopTweenAnim(BuffItem.EChildType.AnimStart);
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIItemScale(global::Vector.OneVector);
			}
			this.PlayFadeAnim(false);
			this.PlayTweenAnim(BuffItem.EChildType.AnimClose);
			this.AnimCloseEndTime = Singleton<Time>.Instance.Now + 200.0;
		}

		// Token: 0x0603DDE6 RID: 253414 RVA: 0x00FC695E File Offset: 0x00FC4B5E
		public override void PlayAddBuffAnim()
		{
			this.PlayTweenAnim(BuffItem.EChildType.AnimAddBuff);
		}

		// Token: 0x0603DDE7 RID: 253415 RVA: 0x00FC6968 File Offset: 0x00FC4B68
		protected override void OnBeforeHide()
		{
			this.PlayFadeAnim(false);
		}

		// Token: 0x0603DDE8 RID: 253416 RVA: 0x00FC6974 File Offset: 0x00FC4B74
		protected override bool DestroyOverride()
		{
			if (this.RootActor != null)
			{
				if (!string.IsNullOrEmpty(this.IconColorStr) && this.BuffTexture != null)
				{
					this.BuffTexture.SetColor(ColorUtils.ColorWhile);
					this.IconColorStr = null;
				}
				ControllerBase<BattleUiControl>.Instance.Pool.RecycleBuffItem(this.RootActor);
			}
			return true;
		}

		// Token: 0x0603DDE9 RID: 253417 RVA: 0x00FC69CC File Offset: 0x00FC4BCC
		private void InitTweenAnim(BuffItem.EChildType componentType)
		{
			List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>();
			TArray<UActorComponent> tarray = base.GetItem((int)componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				list.Add((ULGUIPlayTweenComponent)tarray.Get(i));
			}
			this.TweenAnimMap[(int)componentType] = list;
		}

		// Token: 0x0603DDEA RID: 253418 RVA: 0x00FC6A30 File Offset: 0x00FC4C30
		private void PlayTweenAnim(BuffItem.EChildType componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue((int)componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Play();
				}
			}
		}

		// Token: 0x0603DDEB RID: 253419 RVA: 0x00FC6A8C File Offset: 0x00FC4C8C
		private void StopTweenAnim(BuffItem.EChildType componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue((int)componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Stop();
				}
			}
		}

		// Token: 0x04022B26 RID: 142118
		private const double CLOSE_ANIM_TIME = 200.0;

		// Token: 0x04022B27 RID: 142119
		private const float FADE_ANIM_PERCENT = 0.2f;

		// Token: 0x04022B28 RID: 142120
		[Nullable(1)]
		private const string BUFF = "1";

		// Token: 0x04022B29 RID: 142121
		[Nullable(1)]
		private const string DEBUFF = "2";

		// Token: 0x04022B2A RID: 142122
		[Nullable(1)]
		private readonly Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x04022B2B RID: 142123
		private UUITexture BuffTexture;

		// Token: 0x04022B2C RID: 142124
		private UUITexture LargeBuffTexture;

		// Token: 0x04022B2D RID: 142125
		private UUIText NumText;

		// Token: 0x04022B2E RID: 142126
		private UUISprite BarSprite;

		// Token: 0x04022B2F RID: 142127
		private UUISprite BgSprite;

		// Token: 0x04022B30 RID: 142128
		private UUISprite BarRoundSprite;

		// Token: 0x04022B31 RID: 142129
		private UUISprite BgRoundSprite;

		// Token: 0x04022B32 RID: 142130
		private UUISprite CurBarSprite;

		// Token: 0x04022B33 RID: 142131
		private UUIItem ColorfulFrame;

		// Token: 0x04022B34 RID: 142132
		private bool AlwaysFullPercent;

		// Token: 0x04022B35 RID: 142133
		[Nullable(1)]
		private string IconPath = string.Empty;

		// Token: 0x04022B36 RID: 142134
		private int IconType;

		// Token: 0x04022B37 RID: 142135
		private bool MergeBuffItem;

		// Token: 0x04022B38 RID: 142136
		private int Num;

		// Token: 0x04022B39 RID: 142137
		private float Percent;

		// Token: 0x04022B3A RID: 142138
		private IActiveBuff Buff;

		// Token: 0x04022B3B RID: 142139
		private FColor? DefaultBarColor;

		// Token: 0x04022B3C RID: 142140
		private string IconColorStr;

		// Token: 0x04022B3D RID: 142141
		private double AnimCloseEndTime;

		// Token: 0x04022B3E RID: 142142
		private bool IsPlayingFadeAnim;

		// Token: 0x0200C081 RID: 49281
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B450 RID: 242768
			BuffCtrlItem,
			// Token: 0x0403B451 RID: 242769
			BuffTexture,
			// Token: 0x0403B452 RID: 242770
			BarSprite,
			// Token: 0x0403B453 RID: 242771
			NumText,
			// Token: 0x0403B454 RID: 242772
			DownSprite,
			// Token: 0x0403B455 RID: 242773
			AnimStart,
			// Token: 0x0403B456 RID: 242774
			AnimClose,
			// Token: 0x0403B457 RID: 242775
			AnimFade,
			// Token: 0x0403B458 RID: 242776
			UpSprite,
			// Token: 0x0403B459 RID: 242777
			BgSprite,
			// Token: 0x0403B45A RID: 242778
			LargeBuffTexture,
			// Token: 0x0403B45B RID: 242779
			BgRoundSprite,
			// Token: 0x0403B45C RID: 242780
			BarRoundSprite,
			// Token: 0x0403B45D RID: 242781
			AnimAddBuff,
			// Token: 0x0403B45E RID: 242782
			ColorfulFrame
		}
	}
}

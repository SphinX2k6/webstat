using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Fight.UI;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006003 RID: 24579
	public class EnvironmentItem : UiPanelBase
	{
		// Token: 0x0603DE66 RID: 253542 RVA: 0x00FC9D90 File Offset: 0x00FC7F90
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DE67 RID: 253543 RVA: 0x00FC9F47 File Offset: 0x00FC8147
		public void InitPropertyId(int propertyId)
		{
			this.PropertyConfig = ModelBase<BattleUiModel>.Instance.FormationData.GetUiEnvironmentProperty(propertyId);
			this.WarningPercent = this.PropertyConfig.WarningPercent;
		}

		// Token: 0x0603DE68 RID: 253544 RVA: 0x00FC9F70 File Offset: 0x00FC8170
		protected override UniTask OnCreateAsync()
		{
			EnvironmentItem.<OnCreateAsync>d__17 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<EnvironmentItem.<OnCreateAsync>d__17>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DE69 RID: 253545 RVA: 0x00FC9FB4 File Offset: 0x00FC81B4
		[NullableContext(1)]
		private UniTask LoadSprite(string path, int index)
		{
			EnvironmentItem.<LoadSprite>d__18 <LoadSprite>d__;
			<LoadSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadSprite>d__.<>4__this = this;
			<LoadSprite>d__.path = path;
			<LoadSprite>d__.index = index;
			<LoadSprite>d__.<>1__state = -1;
			<LoadSprite>d__.<>t__builder.Start<EnvironmentItem.<LoadSprite>d__18>(ref <LoadSprite>d__);
			return <LoadSprite>d__.<>t__builder.Task;
		}

		// Token: 0x0603DE6A RID: 253546 RVA: 0x00FCA008 File Offset: 0x00FC8208
		protected override void OnStart()
		{
			this.SetSpriteData(EnvironmentItem.EChildType.Frame, EnvironmentItem.ESprite.Frame);
			this.SetSpriteData(EnvironmentItem.EChildType.Icon, EnvironmentItem.ESprite.Icon);
			this.SetSpriteData(EnvironmentItem.EChildType.IconFull, EnvironmentItem.ESprite.IconFull);
			this.SpriteDataList.Clear();
			SUiEnvironmentProperty propertyConfig = this.PropertyConfig;
			string text = (propertyConfig != null) ? propertyConfig.SceneEffect.ToAssetPathName() : null;
			if (this.EffectPath != text)
			{
				this.DestroyCurSceneEffect();
				this.EffectPath = text;
				this.LoadSceneEffect();
			}
			UUISprite sprite = base.GetSprite(2);
			UUISprite sprite2 = base.GetSprite(11);
			if (this.PropertyConfig != null)
			{
				TArray<FColor> colors = this.PropertyConfig.Colors;
				if (colors.Num() >= 2)
				{
					if (sprite != null)
					{
						sprite.SetColor(colors.Get(0));
					}
					if (sprite2 != null)
					{
						sprite2.SetColor(colors.Get(1));
					}
				}
			}
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			this.InitTweenAnim(EnvironmentItem.EChildType.AnimStart);
			this.InitTweenAnim(EnvironmentItem.EChildType.AnimWarningA);
			this.InitTweenAnim(EnvironmentItem.EChildType.AnimWarningB);
			this.InitTweenAnim(EnvironmentItem.EChildType.AnimBurst);
			this.InitTweenAnim(EnvironmentItem.EChildType.AnimClose);
		}

		// Token: 0x0603DE6B RID: 253547 RVA: 0x00FCA0F4 File Offset: 0x00FC82F4
		private void SetSpriteData(EnvironmentItem.EChildType childIndex, EnvironmentItem.ESprite spriteIndex)
		{
			UUISprite sprite = base.GetSprite((int)childIndex);
			ULGUISpriteData_BaseObject valueOrDefault = this.SpriteDataList.GetValueOrDefault((int)spriteIndex);
			if (valueOrDefault != null && sprite != null)
			{
				sprite.SetSprite(valueOrDefault, false);
			}
		}

		// Token: 0x0603DE6C RID: 253548 RVA: 0x00FCA124 File Offset: 0x00FC8324
		protected override void OnBeforeShow()
		{
			this.SetPercentInner(this.CurrentValue, this.MaxValue);
		}

		// Token: 0x0603DE6D RID: 253549 RVA: 0x00FCA138 File Offset: 0x00FC8338
		public void SetPercent(float currentValue, float maxValue)
		{
			this.CurrentValue = currentValue;
			this.MaxValue = maxValue;
			if (!base.IsShowOrShowing)
			{
				return;
			}
			this.SetPercentInner(currentValue, maxValue);
		}

		// Token: 0x0603DE6E RID: 253550 RVA: 0x00FCA15C File Offset: 0x00FC835C
		private void SetPercentInner(float currentValue, float maxValue)
		{
			if (currentValue <= 0f || maxValue <= 0f)
			{
				this.Percent = 0f;
				this.TrySetActive(false);
				return;
			}
			if (this.PropertyConfig == null)
			{
				return;
			}
			float num = Math.Min(1f, Math.Max(0f, currentValue / maxValue));
			if (this.Percent == num)
			{
				return;
			}
			this.Percent = num;
			this.TrySetActive(true);
			int num2 = -1;
			int num3;
			if (num < this.WarningPercent)
			{
				num3 = 0;
			}
			else if (num < 1f)
			{
				num3 = 1;
				num2 = 7;
			}
			else
			{
				num3 = 2;
				num2 = 8;
			}
			UUISprite sprite = base.GetSprite(3);
			if (sprite != null)
			{
				sprite.SetFillAmount(num);
			}
			if (this.Stage != num3)
			{
				this.Stage = num3;
				TArray<FColor> bgColors = this.PropertyConfig.BgColors;
				if (bgColors.Num() > num3)
				{
					UUISprite sprite2 = base.GetSprite(0);
					if (sprite2 != null)
					{
						sprite2.SetColor(bgColors.Get(num3));
					}
				}
				TArray<FColor> barColors = this.PropertyConfig.BarColors;
				if (barColors.Num() > num3 && sprite != null)
				{
					sprite.SetColor(barColors.Get(num3));
				}
				UUISprite sprite3 = base.GetSprite(4);
				UUISprite sprite4 = base.GetSprite(5);
				if (num3 == 2)
				{
					if (sprite3 != null)
					{
						sprite3.SetUIActive(false);
					}
					if (sprite4 != null)
					{
						sprite4.SetUIActive(true);
					}
				}
				else
				{
					if (sprite3 != null)
					{
						sprite3.SetUIActive(true);
					}
					if (sprite4 != null)
					{
						sprite4.SetUIActive(false);
					}
				}
			}
			if (this.CurWarningAnim != num2)
			{
				if (this.CurWarningAnim >= 0)
				{
					this.StopTweenAnim((EnvironmentItem.EChildType)this.CurWarningAnim);
				}
				this.CurWarningAnim = num2;
				if (num2 >= 0)
				{
					this.PlayTweenAnim((EnvironmentItem.EChildType)this.CurWarningAnim);
					UUISprite sprite5 = base.GetSprite(2);
					if (sprite5 != null)
					{
						sprite5.SetAlpha(0f);
					}
					UUISprite sprite6 = base.GetSprite(2);
					if (sprite6 != null)
					{
						sprite6.SetUIActive(true);
					}
				}
				else
				{
					UUISprite sprite7 = base.GetSprite(2);
					if (sprite7 != null)
					{
						sprite7.SetUIActive(false);
					}
				}
				if (num3 == 2)
				{
					this.PlayTweenAnim(EnvironmentItem.EChildType.AnimBurst);
				}
			}
			this.UpdateSceneEffect();
		}

		// Token: 0x0603DE6F RID: 253551 RVA: 0x00FCA338 File Offset: 0x00FC8538
		private void TrySetActive(bool visibility)
		{
			if (visibility == this.IsActive)
			{
				return;
			}
			this.IsActive = visibility;
			if (this.EffectData != null)
			{
				if (this.IsActive)
				{
					ScreenEffectSystem.GetInstance().PlayScreenEffect(this.EffectData);
					this.StopTweenAnim(EnvironmentItem.EChildType.AnimClose);
					this.PlayTweenAnim(EnvironmentItem.EChildType.AnimStart);
					return;
				}
				ScreenEffectSystem.GetInstance().EndScreenEffect(this.EffectData);
				this.StopTweenAnim(EnvironmentItem.EChildType.AnimStart);
				if (this.CurWarningAnim >= 0)
				{
					this.StopTweenAnim((EnvironmentItem.EChildType)this.CurWarningAnim);
					UUISprite sprite = base.GetSprite(2);
					if (sprite != null)
					{
						sprite.SetUIActive(false);
					}
					this.CurWarningAnim = -1;
				}
				this.PlayTweenAnim(EnvironmentItem.EChildType.AnimClose);
			}
		}

		// Token: 0x0603DE70 RID: 253552 RVA: 0x00FCA3D4 File Offset: 0x00FC85D4
		private void LoadSceneEffect()
		{
			if (string.IsNullOrEmpty(this.EffectPath))
			{
				return;
			}
			bool isLoading = true;
			this.LoadingEffectId = Singleton<ResourceSystem>.Instance.LoadAsync<EffectScreenPlayData_C>(this.EffectPath, delegate([Nullable(2)] EffectScreenPlayData_C res, string _)
			{
				this.LoadingEffectId = 0;
				isLoading = false;
				this.EffectData = res;
				if (this.IsActive)
				{
					ScreenEffectSystem.GetInstance().PlayScreenEffect(this.EffectData);
					this.UpdateSceneEffect();
				}
			}, 102, "js_undefined");
			if (!isLoading)
			{
				this.LoadingEffectId = 0;
			}
		}

		// Token: 0x0603DE71 RID: 253553 RVA: 0x00FCA43B File Offset: 0x00FC863B
		private void UpdateSceneEffect()
		{
			if (this.EffectData != null)
			{
				ScreenEffectSystem.GetInstance().UpdateSEEnvironmentFactor(this.EffectData, this.Percent);
			}
		}

		// Token: 0x0603DE72 RID: 253554 RVA: 0x00FCA45C File Offset: 0x00FC865C
		private void DestroyCurSceneEffect()
		{
			if (this.LoadingEffectId > 0)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadingEffectId);
				this.LoadingEffectId = 0;
			}
			if (this.EffectData != null)
			{
				ScreenEffectSystem.GetInstance().EndScreenEffect(this.EffectData);
				this.EffectData = null;
			}
			this.EffectPath = null;
		}

		// Token: 0x0603DE73 RID: 253555 RVA: 0x00FCA4AF File Offset: 0x00FC86AF
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			this.DestroyCurSceneEffect();
		}

		// Token: 0x0603DE74 RID: 253556 RVA: 0x00FCA4C0 File Offset: 0x00FC86C0
		private void InitTweenAnim(EnvironmentItem.EChildType componentType)
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

		// Token: 0x0603DE75 RID: 253557 RVA: 0x00FCA524 File Offset: 0x00FC8724
		private void PlayTweenAnim(EnvironmentItem.EChildType componentType)
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

		// Token: 0x0603DE76 RID: 253558 RVA: 0x00FCA580 File Offset: 0x00FC8780
		private void StopTweenAnim(EnvironmentItem.EChildType componentType)
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

		// Token: 0x04022B87 RID: 142215
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly List<ULGUISpriteData_BaseObject> SpriteDataList = new List<ULGUISpriteData_BaseObject>();

		// Token: 0x04022B88 RID: 142216
		[Nullable(1)]
		private readonly Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x04022B89 RID: 142217
		[Nullable(2)]
		private SUiEnvironmentProperty PropertyConfig;

		// Token: 0x04022B8A RID: 142218
		private float Percent;

		// Token: 0x04022B8B RID: 142219
		private int Stage = -1;

		// Token: 0x04022B8C RID: 142220
		private bool IsActive;

		// Token: 0x04022B8D RID: 142221
		[Nullable(2)]
		private EffectScreenPlayData_C EffectData;

		// Token: 0x04022B8E RID: 142222
		[Nullable(2)]
		private string EffectPath;

		// Token: 0x04022B8F RID: 142223
		private int LoadingEffectId;

		// Token: 0x04022B90 RID: 142224
		private int CurWarningAnim = -1;

		// Token: 0x04022B91 RID: 142225
		private float WarningPercent = 0.8f;

		// Token: 0x04022B92 RID: 142226
		private float CurrentValue;

		// Token: 0x04022B93 RID: 142227
		private float MaxValue;

		// Token: 0x0200C08D RID: 49293
		private enum EChildType
		{
			// Token: 0x0403B493 RID: 242835
			Bg,
			// Token: 0x0403B494 RID: 242836
			Frame,
			// Token: 0x0403B495 RID: 242837
			OutLine,
			// Token: 0x0403B496 RID: 242838
			Bar,
			// Token: 0x0403B497 RID: 242839
			Icon,
			// Token: 0x0403B498 RID: 242840
			IconFull,
			// Token: 0x0403B499 RID: 242841
			AnimStart,
			// Token: 0x0403B49A RID: 242842
			AnimWarningA,
			// Token: 0x0403B49B RID: 242843
			AnimWarningB,
			// Token: 0x0403B49C RID: 242844
			AnimBurst,
			// Token: 0x0403B49D RID: 242845
			AnimClose,
			// Token: 0x0403B49E RID: 242846
			AnimBurstSprite
		}

		// Token: 0x0200C08E RID: 49294
		private enum ESprite
		{
			// Token: 0x0403B4A0 RID: 242848
			Frame,
			// Token: 0x0403B4A1 RID: 242849
			Icon,
			// Token: 0x0403B4A2 RID: 242850
			IconFull
		}
	}
}

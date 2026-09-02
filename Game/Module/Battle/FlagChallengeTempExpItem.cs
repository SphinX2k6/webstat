using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F29 RID: 24361
	public class FlagChallengeTempExpItem : UiPanelBase
	{
		// Token: 0x0603D2D5 RID: 250581 RVA: 0x00F8C08C File Offset: 0x00F8A28C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D2D6 RID: 250582 RVA: 0x00F8C158 File Offset: 0x00F8A358
		protected override void OnStart()
		{
			base.OnStart();
			base.SetUiActive(false);
			UUIItem item = base.GetItem(1);
			TArray<UActorComponent> tarray;
			if (item == null)
			{
				tarray = null;
			}
			else
			{
				AActor owner = item.GetOwner();
				tarray = ((owner != null) ? owner.K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass()) : null);
			}
			TArray<UActorComponent> tarray2 = tarray;
			if (tarray2 != null && tarray2.Num() > 0)
			{
				if (this.TweenInComps == null)
				{
					this.TweenInComps = new List<ULGUIPlayTweenComponent>();
				}
				foreach (UActorComponent uactorComponent in tarray2)
				{
					this.TweenInComps.Add((ULGUIPlayTweenComponent)uactorComponent);
				}
			}
			UUIItem item2 = base.GetItem(2);
			TArray<UActorComponent> tarray3;
			if (item2 == null)
			{
				tarray3 = null;
			}
			else
			{
				AActor owner2 = item2.GetOwner();
				tarray3 = ((owner2 != null) ? owner2.K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass()) : null);
			}
			TArray<UActorComponent> tarray4 = tarray3;
			if (tarray4 != null && tarray4.Num() > 0)
			{
				if (this.TweenOutComps == null)
				{
					this.TweenOutComps = new List<ULGUIPlayTweenComponent>();
				}
				foreach (UActorComponent uactorComponent2 in tarray4)
				{
					this.TweenOutComps.Add((ULGUIPlayTweenComponent)uactorComponent2);
				}
			}
			UUIItem item3 = base.GetItem(4);
			TArray<UActorComponent> tarray5;
			if (item3 == null)
			{
				tarray5 = null;
			}
			else
			{
				AActor owner3 = item3.GetOwner();
				tarray5 = ((owner3 != null) ? owner3.K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass()) : null);
			}
			TArray<UActorComponent> tarray6 = tarray5;
			if (tarray6 != null && tarray6.Num() > 0)
			{
				if (this.TweenRedComps == null)
				{
					this.TweenRedComps = new List<ULGUIPlayTweenComponent>();
				}
				foreach (UActorComponent uactorComponent3 in tarray6)
				{
					this.TweenRedComps.Add((ULGUIPlayTweenComponent)uactorComponent3);
				}
			}
			this.ArrowSprite = base.GetSprite(0);
		}

		// Token: 0x0603D2D7 RID: 250583 RVA: 0x00F8C328 File Offset: 0x00F8A528
		public void Clean()
		{
			this.TweenInComps = null;
			this.TweenOutComps = null;
		}

		// Token: 0x0603D2D8 RID: 250584 RVA: 0x00F8C338 File Offset: 0x00F8A538
		public void SetIndex(int index)
		{
			this.Index = index;
			this.StartProgress = (float)index * 0.1f;
		}

		// Token: 0x0603D2D9 RID: 250585 RVA: 0x00F8C34F File Offset: 0x00F8A54F
		public int GetIndex()
		{
			return this.Index;
		}

		// Token: 0x0603D2DA RID: 250586 RVA: 0x00F8C357 File Offset: 0x00F8A557
		public bool IsShowItem(float progress)
		{
			return progress > this.StartProgress;
		}

		// Token: 0x0603D2DB RID: 250587 RVA: 0x00F8C362 File Offset: 0x00F8A562
		public bool IsHideItem(float progress)
		{
			return progress <= this.StartProgress;
		}

		// Token: 0x0603D2DC RID: 250588 RVA: 0x00F8C370 File Offset: 0x00F8A570
		public void Reset()
		{
			if (this.IsPlayTweenOut)
			{
				this.StopTweenOut();
				UUISprite arrowSprite = this.ArrowSprite;
				if (arrowSprite != null)
				{
					arrowSprite.SetAlpha(1f);
				}
			}
			bool isPlayTweenRed = this.IsPlayTweenRed;
			this.IsPlayTweenIn = false;
			this.IsPlayTweenOut = false;
			this.IsPlayTweenRed = false;
		}

		// Token: 0x0603D2DD RID: 250589 RVA: 0x00F8C3BD File Offset: 0x00F8A5BD
		public void ShowItem()
		{
			base.SetUiActive(true);
		}

		// Token: 0x0603D2DE RID: 250590 RVA: 0x00F8C3C6 File Offset: 0x00F8A5C6
		public void HideItem(bool playAnim = true)
		{
			base.SetUiActive(false);
		}

		// Token: 0x0603D2DF RID: 250591 RVA: 0x00F8C3D0 File Offset: 0x00F8A5D0
		public void PlayTweenIn()
		{
			if (this.TweenInComps == null || this.IsPlayTweenIn)
			{
				return;
			}
			this.IsPlayTweenIn = true;
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.TweenInComps)
			{
				ulguiplayTweenComponent.Play();
			}
		}

		// Token: 0x0603D2E0 RID: 250592 RVA: 0x00F8C438 File Offset: 0x00F8A638
		public void PlayTweenOut()
		{
			if (this.TweenOutComps == null || this.IsPlayTweenOut)
			{
				return;
			}
			this.IsPlayTweenOut = true;
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.TweenOutComps)
			{
				ulguiplayTweenComponent.Play();
			}
		}

		// Token: 0x0603D2E1 RID: 250593 RVA: 0x00F8C4A0 File Offset: 0x00F8A6A0
		public void PlayTweenRed()
		{
			if (this.TweenRedComps == null)
			{
				return;
			}
			this.IsPlayTweenRed = true;
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.TweenRedComps)
			{
				ulguiplayTweenComponent.Play();
			}
		}

		// Token: 0x0603D2E2 RID: 250594 RVA: 0x00F8C500 File Offset: 0x00F8A700
		public void StopTweenOut()
		{
			if (this.TweenOutComps == null || !this.IsPlayTweenOut)
			{
				return;
			}
			this.IsPlayTweenOut = false;
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.TweenOutComps)
			{
				ulguiplayTweenComponent.Stop();
			}
		}

		// Token: 0x0603D2E3 RID: 250595 RVA: 0x00F8C568 File Offset: 0x00F8A768
		public void PlayTweenAnim(EFlagChallengeExpItemTweenAnimType tweenType)
		{
			switch (tweenType)
			{
			case EFlagChallengeExpItemTweenAnimType.In:
				this.PlayTweenIn();
				return;
			case EFlagChallengeExpItemTweenAnimType.Out:
				this.PlayTweenOut();
				return;
			case EFlagChallengeExpItemTweenAnimType.Break:
				break;
			case EFlagChallengeExpItemTweenAnimType.Red:
				this.PlayTweenRed();
				break;
			default:
				return;
			}
		}

		// Token: 0x040224E1 RID: 140513
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ULGUIPlayTweenComponent> TweenInComps;

		// Token: 0x040224E2 RID: 140514
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ULGUIPlayTweenComponent> TweenOutComps;

		// Token: 0x040224E3 RID: 140515
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ULGUIPlayTweenComponent> TweenRedComps;

		// Token: 0x040224E4 RID: 140516
		[Nullable(2)]
		private UUISprite ArrowSprite;

		// Token: 0x040224E5 RID: 140517
		private int Index;

		// Token: 0x040224E6 RID: 140518
		private float StartProgress;

		// Token: 0x040224E7 RID: 140519
		private bool IsPlayTweenIn;

		// Token: 0x040224E8 RID: 140520
		private bool IsPlayTweenOut;

		// Token: 0x040224E9 RID: 140521
		private bool IsPlayTweenRed;

		// Token: 0x0200BF39 RID: 48953
		private enum EComponentType
		{
			// Token: 0x0403ADC4 RID: 241092
			ArrowSprite,
			// Token: 0x0403ADC5 RID: 241093
			TweenIn,
			// Token: 0x0403ADC6 RID: 241094
			TweenOut,
			// Token: 0x0403ADC7 RID: 241095
			TweenBreakOff,
			// Token: 0x0403ADC8 RID: 241096
			TweenRed
		}
	}
}

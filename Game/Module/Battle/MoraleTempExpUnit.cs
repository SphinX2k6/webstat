using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F3C RID: 24380
	public class MoraleTempExpUnit : UiPanelBase
	{
		// Token: 0x0603D41B RID: 250907 RVA: 0x00F9452C File Offset: 0x00F9272C
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

		// Token: 0x0603D41C RID: 250908 RVA: 0x00F945F8 File Offset: 0x00F927F8
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
			if (tarray2 != null)
			{
				foreach (UActorComponent uactorComponent in tarray2)
				{
					if (this.TweenInComps == null)
					{
						this.TweenInComps = new List<ULGUIPlayTweenComponent>();
					}
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
			if (tarray4 != null)
			{
				foreach (UActorComponent uactorComponent2 in tarray4)
				{
					if (this.TweenOutComps == null)
					{
						this.TweenOutComps = new List<ULGUIPlayTweenComponent>();
					}
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
			if (tarray6 != null)
			{
				foreach (UActorComponent uactorComponent3 in tarray6)
				{
					if (this.TweenRedComps == null)
					{
						this.TweenRedComps = new List<ULGUIPlayTweenComponent>();
					}
					this.TweenRedComps.Add((ULGUIPlayTweenComponent)uactorComponent3);
				}
			}
			this.ArrowSprite = base.GetSprite(0);
		}

		// Token: 0x0603D41D RID: 250909 RVA: 0x00F947AC File Offset: 0x00F929AC
		public void Clean()
		{
			this.TweenInComps = null;
			this.TweenOutComps = null;
		}

		// Token: 0x0603D41E RID: 250910 RVA: 0x00F947BC File Offset: 0x00F929BC
		public void SetIndex(int index)
		{
			this.Index = index;
			this.StartProgress = (float)index * 0.1f;
		}

		// Token: 0x0603D41F RID: 250911 RVA: 0x00F947D3 File Offset: 0x00F929D3
		public bool IsShowUnit(float progress)
		{
			return progress > this.StartProgress;
		}

		// Token: 0x0603D420 RID: 250912 RVA: 0x00F947DE File Offset: 0x00F929DE
		public bool IsHideUnit(float progress)
		{
			return progress <= this.StartProgress;
		}

		// Token: 0x0603D421 RID: 250913 RVA: 0x00F947EC File Offset: 0x00F929EC
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

		// Token: 0x0603D422 RID: 250914 RVA: 0x00F94839 File Offset: 0x00F92A39
		public void ShowUnit()
		{
			base.SetUiActive(true);
		}

		// Token: 0x0603D423 RID: 250915 RVA: 0x00F94842 File Offset: 0x00F92A42
		public void HideUnit(bool playAnim = true)
		{
			base.SetUiActive(false);
		}

		// Token: 0x0603D424 RID: 250916 RVA: 0x00F9484C File Offset: 0x00F92A4C
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

		// Token: 0x0603D425 RID: 250917 RVA: 0x00F948B4 File Offset: 0x00F92AB4
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

		// Token: 0x0603D426 RID: 250918 RVA: 0x00F9491C File Offset: 0x00F92B1C
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

		// Token: 0x0603D427 RID: 250919 RVA: 0x00F9497C File Offset: 0x00F92B7C
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

		// Token: 0x0603D428 RID: 250920 RVA: 0x00F949E4 File Offset: 0x00F92BE4
		public void PlayTweenAnim(MoraleTempExpView.ETweenAnimType tweenType)
		{
			switch (tweenType)
			{
			case MoraleTempExpView.ETweenAnimType.In:
				this.PlayTweenIn();
				return;
			case MoraleTempExpView.ETweenAnimType.Out:
				this.PlayTweenOut();
				return;
			case MoraleTempExpView.ETweenAnimType.Break:
				break;
			case MoraleTempExpView.ETweenAnimType.Red:
				this.PlayTweenRed();
				break;
			default:
				return;
			}
		}

		// Token: 0x040225B6 RID: 140726
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ULGUIPlayTweenComponent> TweenInComps;

		// Token: 0x040225B7 RID: 140727
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ULGUIPlayTweenComponent> TweenOutComps;

		// Token: 0x040225B8 RID: 140728
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ULGUIPlayTweenComponent> TweenRedComps;

		// Token: 0x040225B9 RID: 140729
		[Nullable(2)]
		private UUISprite ArrowSprite;

		// Token: 0x040225BA RID: 140730
		public int Index;

		// Token: 0x040225BB RID: 140731
		private float StartProgress;

		// Token: 0x040225BC RID: 140732
		private bool IsPlayTweenIn;

		// Token: 0x040225BD RID: 140733
		private bool IsPlayTweenOut;

		// Token: 0x040225BE RID: 140734
		private bool IsPlayTweenRed;

		// Token: 0x0200BF67 RID: 48999
		private enum EUnitChildType
		{
			// Token: 0x0403AEA2 RID: 241314
			ArrowSprite,
			// Token: 0x0403AEA3 RID: 241315
			TweenIn,
			// Token: 0x0403AEA4 RID: 241316
			TweenOut,
			// Token: 0x0403AEA5 RID: 241317
			TweenBreakOff,
			// Token: 0x0403AEA6 RID: 241318
			TweenRed
		}
	}
}

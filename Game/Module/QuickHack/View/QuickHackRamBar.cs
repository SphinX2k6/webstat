using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack.View
{
	// Token: 0x02005307 RID: 21255
	[NullableContext(2)]
	[Nullable(0)]
	public class QuickHackRamBar
	{
		// Token: 0x06036431 RID: 222257 RVA: 0x00DAD2D4 File Offset: 0x00DAB4D4
		[NullableContext(1)]
		public void Init(UUISprite darkBlueSprite, UUISprite blueSprite, UUISprite redSpriteA, UUISprite redSpriteB, UUIItem ramItem, [Nullable(2)] UCurveFloat selectedCurve)
		{
			this.IsInit = true;
			this.DarkBlueSprite = darkBlueSprite;
			this.BlueSprite = blueSprite;
			this.RedSpriteA = redSpriteA;
			this.RedSpriteB = redSpriteB;
			this.RamItem = ramItem;
			if (selectedCurve != null && selectedCurve.IsValid())
			{
				this.SelectedRamFrameInterval = 16f;
				this.SelectedCurve = selectedCurve;
			}
			TArray<UActorComponent> tarray = ramItem.GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				this.RamItemAnimList.Add(tarray.Get(i) as ULGUIPlayTweenComponent);
			}
			if (this.RamItemAnimList.Count > 0)
			{
				ULGUIPlayTween playTween = this.RamItemAnimList[0].GetPlayTween();
				if (playTween != null)
				{
					FLGUIPlayTweenCompleteDynamicDelegate flguiplayTweenCompleteDynamicDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(new Action(this.NextReduceRamAnim));
					this.Wrapper = playTween.RegisterOnComplete(flguiplayTweenCompleteDynamicDelegate);
					this.CallbackTween = playTween;
				}
			}
		}

		// Token: 0x06036432 RID: 222258 RVA: 0x00DAD3BC File Offset: 0x00DAB5BC
		public void Clear()
		{
			this.IsInit = false;
			this.Current = 0;
			this.Max = 0;
			this.Used = 0;
			this.Selected = 0;
			this.DarkBlueSprite = null;
			this.BlueSprite = null;
			this.RedSpriteA = null;
			this.RedSpriteB = null;
			this.RamItem = null;
			this.PlayingReduceRamSize = 0;
			this.SelectedCurve = null;
			this.SelectedRamFrameInterval = 0f;
			this.IsPlayingRamSelected = false;
			this.PlayingRamSelectedDuration = 0f;
			this.PlayingReduceRamIndex = -1;
			this.PlayingReduceRamSize = 0;
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.RamItemAnimList)
			{
				ulguiplayTweenComponent.Stop();
			}
			this.RamItemAnimList.Clear();
			if (this.CallbackTween != null && this.Wrapper != null)
			{
				this.CallbackTween.UnregisterOnComplete(this.Wrapper);
			}
			this.CallbackTween = null;
			this.Wrapper = null;
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.NextReduceRamAnim));
		}

		// Token: 0x06036433 RID: 222259 RVA: 0x00DAD4DC File Offset: 0x00DAB6DC
		public void TickRamBar(float delta)
		{
			if (this.IsInit && this.IsPlayingRamSelected)
			{
				UCurveFloat selectedCurve = this.SelectedCurve;
				if (selectedCurve != null && selectedCurve.IsValid() && this.SelectedRamFrameInterval > 0f)
				{
					float inTime = this.PlayingRamSelectedDuration / this.SelectedRamFrameInterval % 34f;
					float floatValue = this.SelectedCurve.GetFloatValue(inTime);
					float anchorOffsetY = Singleton<MathUtils>.Instance.RangeClamp(floatValue, 0f, 1f, 0f, 6f);
					this.BlueSprite.SetAnchorOffsetY(anchorOffsetY);
					this.PlayingRamSelectedDuration += delta;
					return;
				}
			}
		}

		// Token: 0x06036434 RID: 222260 RVA: 0x00DAD57C File Offset: 0x00DAB77C
		public void RefreshRam(int current, int max, bool playReduceAnim = false)
		{
			if (!this.IsInit)
			{
				return;
			}
			if (current < 0 || max < 0 || current > max)
			{
				return;
			}
			if (this.Current == current && this.Max == max)
			{
				return;
			}
			int reduceSize = (current < this.Current) ? (this.Current - current) : 0;
			this.Current = current;
			this.Max = max;
			this.Used = ((this.Max > this.Current) ? (this.Max - this.Current) : 0);
			this.RefreshAllRamView(playReduceAnim, reduceSize);
		}

		// Token: 0x06036435 RID: 222261 RVA: 0x00DAD601 File Offset: 0x00DAB801
		public void SelectRam(int value)
		{
			if (!this.IsInit)
			{
				return;
			}
			if (this.Selected == value)
			{
				return;
			}
			this.Selected = value;
			this.RefreshEnableRamView();
			if (value > 0)
			{
				this.StartRamSelectedAnim();
				return;
			}
			this.StopRamSelectedAnim();
		}

		// Token: 0x06036436 RID: 222262 RVA: 0x00DAD634 File Offset: 0x00DAB834
		private void RefreshEnableRamView()
		{
			float leftX = this.GetLeftX();
			int num = (this.Current > this.Selected) ? (this.Current - this.Selected) : 0;
			this.UpdateItem(this.DarkBlueSprite, leftX, 0, num, true);
			this.UpdateItem(this.BlueSprite, leftX, num, this.Selected, true);
		}

		// Token: 0x06036437 RID: 222263 RVA: 0x00DAD68C File Offset: 0x00DAB88C
		private void RefreshAllRamView(bool playReduceAnim = false, int reduceSize = 0)
		{
			float leftX = this.GetLeftX();
			int num = (this.Current > this.Selected) ? (this.Current - this.Selected) : 0;
			this.UpdateItem(this.DarkBlueSprite, leftX, 0, num, true);
			this.UpdateItem(this.BlueSprite, leftX, num, this.Selected, true);
			if (playReduceAnim && reduceSize > 0)
			{
				this.StartReduceRamAnim(reduceSize);
				return;
			}
			if (this.IsPlayingReduceRam)
			{
				int num2 = this.PlayingReduceRamIndex - this.Current;
				if (num2 >= 0)
				{
					this.UpdateItem(this.RedSpriteA, leftX, this.Current, num2, true);
					return;
				}
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.RamItemAnimList)
				{
					ulguiplayTweenComponent.Stop();
				}
			}
			this.StopReduceRamAnim();
		}

		// Token: 0x06036438 RID: 222264 RVA: 0x00DAD76C File Offset: 0x00DAB96C
		private void StartRamSelectedAnim()
		{
			if (this.IsPlayingRamSelected)
			{
				return;
			}
			this.IsPlayingRamSelected = true;
			this.BlueSprite.SetAnchorOffsetY(0f);
			this.PlayingRamSelectedDuration = 0f;
		}

		// Token: 0x06036439 RID: 222265 RVA: 0x00DAD799 File Offset: 0x00DAB999
		private void StopRamSelectedAnim()
		{
			if (!this.IsPlayingRamSelected)
			{
				return;
			}
			this.IsPlayingRamSelected = false;
		}

		// Token: 0x0603643A RID: 222266 RVA: 0x00DAD7AC File Offset: 0x00DAB9AC
		private void StartReduceRamAnim(int reduceSize)
		{
			if (this.IsPlayingReduceRam)
			{
				this.PlayingReduceRamSize += reduceSize;
				int num = this.PlayingReduceRamIndex - this.Current;
				if (num >= 0)
				{
					this.UpdateItem(this.RedSpriteA, this.GetLeftX(), this.Current, num, true);
				}
				return;
			}
			this.IsPlayingReduceRam = true;
			this.RedSpriteA.SetUIActive(true);
			this.RamItem.SetUIActive(true);
			this.PlayingReduceRamIndex = this.Current + reduceSize - 1;
			this.PlayingReduceRamSize += reduceSize;
			this.NextReduceRamAnim();
		}

		// Token: 0x0603643B RID: 222267 RVA: 0x00DAD840 File Offset: 0x00DABA40
		private void NextReduceRamAnim()
		{
			if (!this.IsInit || !this.IsPlayingReduceRam)
			{
				return;
			}
			if (this.PlayingReduceRamSize <= 0)
			{
				this.StopReduceRamAnim();
				return;
			}
			int num = this.PlayingReduceRamIndex - this.Current;
			if (num < 0)
			{
				this.StopReduceRamAnim();
				return;
			}
			this.PlayingReduceRamIndex--;
			this.PlayingReduceRamSize--;
			float leftX = this.GetLeftX();
			this.UpdateItem(this.RedSpriteA, leftX, this.Current, num, true);
			int num2 = this.Current + num;
			this.UpdateItem(this.RamItem, leftX, num2, 1, false);
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.RamItemAnimList)
			{
				ulguiplayTweenComponent.Play();
			}
			int size = this.Used - num - 1;
			this.UpdateItem(this.RedSpriteB, leftX, num2 + 1, size, true);
		}

		// Token: 0x0603643C RID: 222268 RVA: 0x00DAD93C File Offset: 0x00DABB3C
		private void StopReduceRamAnim()
		{
			this.IsPlayingReduceRam = false;
			this.UpdateItem(this.RedSpriteB, this.GetLeftX(), this.Current, this.Used, true);
			this.RedSpriteA.SetUIActive(false);
			this.RamItem.SetUIActive(false);
			this.PlayingReduceRamIndex = -1;
			this.PlayingReduceRamSize = 0;
		}

		// Token: 0x0603643D RID: 222269 RVA: 0x00DAD995 File Offset: 0x00DABB95
		private float GetLeftX()
		{
			return -((float)this.Max / 2f) * 28f;
		}

		// Token: 0x0603643E RID: 222270 RVA: 0x00DAD9AC File Offset: 0x00DABBAC
		[NullableContext(1)]
		private void UpdateItem(UUIItem item, float startX, int preSize, int size, bool updateWidth = true)
		{
			float num = (float)(size * 28);
			float anchorOffsetX = startX + (float)(preSize * 28) + num / 2f;
			item.SetAnchorOffsetX(anchorOffsetX);
			if (updateWidth)
			{
				item.SetWidth(num);
			}
		}

		// Token: 0x0401F30D RID: 127757
		private bool IsInit;

		// Token: 0x0401F30E RID: 127758
		private int Current;

		// Token: 0x0401F30F RID: 127759
		private int Max;

		// Token: 0x0401F310 RID: 127760
		private int Used;

		// Token: 0x0401F311 RID: 127761
		private int Selected;

		// Token: 0x0401F312 RID: 127762
		private UUISprite DarkBlueSprite;

		// Token: 0x0401F313 RID: 127763
		private UUISprite BlueSprite;

		// Token: 0x0401F314 RID: 127764
		private UUISprite RedSpriteA;

		// Token: 0x0401F315 RID: 127765
		private UUISprite RedSpriteB;

		// Token: 0x0401F316 RID: 127766
		private UUIItem RamItem;

		// Token: 0x0401F317 RID: 127767
		private UCurveFloat SelectedCurve;

		// Token: 0x0401F318 RID: 127768
		private float SelectedRamFrameInterval;

		// Token: 0x0401F319 RID: 127769
		private bool IsPlayingRamSelected;

		// Token: 0x0401F31A RID: 127770
		private float PlayingRamSelectedDuration;

		// Token: 0x0401F31B RID: 127771
		private bool IsPlayingReduceRam;

		// Token: 0x0401F31C RID: 127772
		private int PlayingReduceRamIndex = -1;

		// Token: 0x0401F31D RID: 127773
		private int PlayingReduceRamSize;

		// Token: 0x0401F31E RID: 127774
		[Nullable(1)]
		private readonly List<ULGUIPlayTweenComponent> RamItemAnimList = new List<ULGUIPlayTweenComponent>();

		// Token: 0x0401F31F RID: 127775
		private ULGUIPlayTween CallbackTween;

		// Token: 0x0401F320 RID: 127776
		private FLGUIDelegateHandleWrapper Wrapper;
	}
}

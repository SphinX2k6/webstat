using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049C1 RID: 18881
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonDragLogicDataItem<T> where T : class
	{
		// Token: 0x06031624 RID: 202276 RVA: 0x00C4A362 File Offset: 0x00C48562
		[NullableContext(2)]
		public void SetCurrentData(T data)
		{
			this.CurrentData = data;
		}

		// Token: 0x06031625 RID: 202277 RVA: 0x00C4A36B File Offset: 0x00C4856B
		[NullableContext(2)]
		public T GetCurrentData()
		{
			return this.CurrentData;
		}

		// Token: 0x06031626 RID: 202278 RVA: 0x00C4A374 File Offset: 0x00C48574
		public void SetDragComponent(UUIDraggableComponent drag)
		{
			this.DragComponent = drag;
			this.SourceWidth = this.DragComponent.RootUIComp.Get().Width;
			this.SourceHeight = this.DragComponent.RootUIComp.Get().Height;
		}

		// Token: 0x06031627 RID: 202279 RVA: 0x00C4A3C4 File Offset: 0x00C485C4
		public void SetCurrentIndex(int index)
		{
			this.Index = index;
		}

		// Token: 0x06031628 RID: 202280 RVA: 0x00C4A3CD File Offset: 0x00C485CD
		public int GetCurrentIndex()
		{
			return this.Index;
		}

		// Token: 0x06031629 RID: 202281 RVA: 0x00C4A3D5 File Offset: 0x00C485D5
		public virtual bool CheckIfCanDrag()
		{
			return true;
		}

		// Token: 0x0603162A RID: 202282 RVA: 0x00C4A3D8 File Offset: 0x00C485D8
		public virtual bool CheckIfCurrentDragIndex(int index)
		{
			return true;
		}

		// Token: 0x0603162B RID: 202283 RVA: 0x00C4A3DB File Offset: 0x00C485DB
		public virtual void SetCurrentDragIndex(int index)
		{
		}

		// Token: 0x0603162C RID: 202284 RVA: 0x00C4A3DD File Offset: 0x00C485DD
		public virtual void ClearCurrentDragIndex()
		{
		}

		// Token: 0x0603162D RID: 202285 RVA: 0x00C4A3E0 File Offset: 0x00C485E0
		[NullableContext(0)]
		public ValueTuple<float, float> GetMiddlePosition()
		{
			return new ValueTuple<float, float>(this.DragComponent.RootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().X, this.DragComponent.RootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().Y);
		}

		// Token: 0x0603162E RID: 202286 RVA: 0x00C4A42C File Offset: 0x00C4862C
		public bool CheckIfSelfItem(int index)
		{
			return index == this.Index;
		}

		// Token: 0x0603162F RID: 202287 RVA: 0x00C4A438 File Offset: 0x00C48638
		public bool CheckOverlap(Vector2D inX, Vector2D inY)
		{
			double x = inX.X;
			double y = inX.Y;
			double x2 = inY.X;
			double y2 = inY.Y;
			double x3 = this.GetBounceX().X;
			double y3 = this.GetBounceX().Y;
			double x4 = this.GetBounceY().X;
			double y4 = this.GetBounceY().Y;
			return x < y3 && x3 < y && x2 < y4 && x4 < y2;
		}

		// Token: 0x06031630 RID: 202288 RVA: 0x00C4A4A8 File Offset: 0x00C486A8
		public Vector2D GetBounceX()
		{
			float num = ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetX() * (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetXDir();
			TWeakObjectPtr<UUIItem> rootUIComp = this.DragComponent.RootUIComp;
			float num2 = this.SourceWidth / 2f;
			float num3 = rootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().X - num2;
			float num4 = rootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().X + num2;
			this.BounceX.X = (double)(num3 - num);
			this.BounceX.Y = (double)(num4 - num);
			return this.BounceX;
		}

		// Token: 0x06031631 RID: 202289 RVA: 0x00C4A534 File Offset: 0x00C48734
		public Vector2D GetBounceY()
		{
			float num = ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetY() * (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetYDir();
			TWeakObjectPtr<UUIItem> rootUIComp = this.DragComponent.RootUIComp;
			float num2 = this.SourceHeight / 2f;
			float num3 = rootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().Y - num2;
			float num4 = rootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().Y + num2;
			this.BounceY.X = (double)(num3 - num);
			this.BounceY.Y = (double)(num4 - num);
			return this.BounceY;
		}

		// Token: 0x06031632 RID: 202290 RVA: 0x00C4A5BF File Offset: 0x00C487BF
		public void SetOnUnOverlayCallBack(Action<int> callBack)
		{
			this.OnUnOverlayCallBack = callBack;
		}

		// Token: 0x06031633 RID: 202291 RVA: 0x00C4A5C8 File Offset: 0x00C487C8
		public void SetOnOverlayCallBack(Action<int> callBack)
		{
			this.OnOverlayCallBack = callBack;
		}

		// Token: 0x06031634 RID: 202292 RVA: 0x00C4A5D1 File Offset: 0x00C487D1
		public void OnUnOverlay()
		{
			Action<int> onUnOverlayCallBack = this.OnUnOverlayCallBack;
			if (onUnOverlayCallBack == null)
			{
				return;
			}
			onUnOverlayCallBack(this.GetCurrentIndex());
		}

		// Token: 0x06031635 RID: 202293 RVA: 0x00C4A5E9 File Offset: 0x00C487E9
		public void OnOverlay()
		{
			Action<int> onOverlayCallBack = this.OnOverlayCallBack;
			if (onOverlayCallBack == null)
			{
				return;
			}
			onOverlayCallBack(this.GetCurrentIndex());
		}

		// Token: 0x06031636 RID: 202294 RVA: 0x00C4A604 File Offset: 0x00C48804
		public int GetOverlapIndex(List<CommonDragLogicDataItem<T>> targets)
		{
			int count = targets.Count;
			if (count == 0)
			{
				return -1;
			}
			ValueTuple<float, float> middlePosition = this.GetMiddlePosition();
			int currentIndex = targets[0].GetCurrentIndex();
			ValueTuple<float, float> middlePosition2 = targets[0].GetMiddlePosition();
			float num = middlePosition.Item1 * middlePosition.Item1;
			float num2 = middlePosition.Item2 * middlePosition.Item2;
			float num3 = Math.Abs(num - middlePosition2.Item1 * middlePosition2.Item1);
			float num4 = Math.Abs(num2 - middlePosition2.Item2 * middlePosition2.Item2);
			float num5 = num3 + num4;
			for (int i = 0; i < count; i++)
			{
				middlePosition2 = targets[i].GetMiddlePosition();
				float num6 = Math.Abs(num - middlePosition2.Item1 * middlePosition2.Item1);
				num4 = Math.Abs(num2 - middlePosition2.Item2 * middlePosition2.Item2);
				float num7 = num6 + num4;
				if (num5 > num7)
				{
					num5 = num7;
					currentIndex = targets[i].GetCurrentIndex();
				}
			}
			return currentIndex;
		}

		// Token: 0x06031637 RID: 202295 RVA: 0x00C4A6F5 File Offset: 0x00C488F5
		public virtual float GetClickTime()
		{
			return 300f;
		}

		// Token: 0x0401C5E4 RID: 116196
		[Nullable(2)]
		private UUIDraggableComponent DragComponent;

		// Token: 0x0401C5E5 RID: 116197
		private int Index = -1;

		// Token: 0x0401C5E6 RID: 116198
		[Nullable(2)]
		private T CurrentData;

		// Token: 0x0401C5E7 RID: 116199
		private readonly Vector2D BounceX = new Vector2D(0.0, 0.0);

		// Token: 0x0401C5E8 RID: 116200
		private readonly Vector2D BounceY = new Vector2D(0.0, 0.0);

		// Token: 0x0401C5E9 RID: 116201
		private float SourceWidth;

		// Token: 0x0401C5EA RID: 116202
		private float SourceHeight;

		// Token: 0x0401C5EB RID: 116203
		[Nullable(2)]
		private Action<int> OnOverlayCallBack;

		// Token: 0x0401C5EC RID: 116204
		[Nullable(2)]
		private Action<int> OnUnOverlayCallBack;
	}
}

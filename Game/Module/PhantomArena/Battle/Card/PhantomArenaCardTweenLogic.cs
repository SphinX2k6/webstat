using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card
{
	// Token: 0x02005623 RID: 22051
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCardTweenLogic
	{
		// Token: 0x0603832D RID: 230189 RVA: 0x00E3B1D0 File Offset: 0x00E393D0
		private void CreateTween()
		{
			this.LocationXTween = new LguiFloatTween();
			this.LocationXTween.BindUpdateTween(delegate(float value)
			{
				this.CardWorldPos.X = (double)value;
				UUIItem cardItem = this.CardItem;
				FVector fvector = this.CardWorldPos.ToUeVectorOld();
				cardItem.SetUIWorldLocation(fvector);
			});
			this.LocationXTween.BindCompleteTween(delegate
			{
				this.CardWorldPos.X = this.ToPos.X;
				UUIItem cardItem = this.CardItem;
				FVector fvector = this.CardWorldPos.ToUeVectorOld();
				cardItem.SetUIWorldLocation(fvector);
				this.HandleCompleteTween();
			});
			this.LocationYTween = new LguiFloatTween();
			this.LocationYTween.BindUpdateTween(delegate(float value)
			{
				this.CardWorldPos.Z = (double)value;
				UUIItem cardItem = this.CardItem;
				FVector fvector = this.CardWorldPos.ToUeVectorOld();
				cardItem.SetUIWorldLocation(fvector);
			});
			this.LocationYTween.BindCompleteTween(delegate
			{
				this.CardWorldPos.Z = this.ToPos.Z;
				UUIItem cardItem = this.CardItem;
				FVector fvector = this.CardWorldPos.ToUeVectorOld();
				cardItem.SetUIWorldLocation(fvector);
				this.HandleCompleteTween();
			});
		}

		// Token: 0x0603832E RID: 230190 RVA: 0x00E3B24F File Offset: 0x00E3944F
		private void HandleCompleteTween()
		{
			if (this.LocationXTween.IsFinished && this.LocationYTween.IsFinished)
			{
				Action completeCallback = this.CompleteCallback;
				if (completeCallback == null)
				{
					return;
				}
				completeCallback();
			}
		}

		// Token: 0x0603832F RID: 230191 RVA: 0x00E3B27B File Offset: 0x00E3947B
		public void Init(UUIItem cardItem)
		{
			this.CardItem = cardItem;
			this.CreateTween();
		}

		// Token: 0x06038330 RID: 230192 RVA: 0x00E3B28A File Offset: 0x00E3948A
		public void Destroy()
		{
			this.LocationXTween.Destroy();
			this.LocationYTween.Destroy();
		}

		// Token: 0x06038331 RID: 230193 RVA: 0x00E3B2A4 File Offset: 0x00E394A4
		public void PlayLocationByItem(UUIItem fromItem, UUIItem toItem, [Nullable(2)] PhantomArenaTweenLogic data = null)
		{
			Vector fromPos = this.FromPos;
			FVectorDouble fvectorDouble = fromItem.D_K2_GetComponentLocation();
			fromPos.DeepCopy(fvectorDouble);
			Vector toPos = this.ToPos;
			fvectorDouble = toItem.D_K2_GetComponentLocation();
			toPos.DeepCopy(fvectorDouble);
			this.CardWorldPos.DeepCopy(this.FromPos);
			UUIItem cardItem = this.CardItem;
			FVector fvector = this.CardWorldPos.ToUeVectorOld();
			cardItem.SetUIWorldLocation(fvector);
			this.LocationXTween.BindStartTween((data != null) ? data.StartCallback : null);
			this.CompleteCallback = ((data != null) ? data.CompleteCallback : null);
			float valueOrDefault = ((data != null) ? data.DurationTime : null).GetValueOrDefault(0.5f);
			this.LocationXTween.PlayTween((float)this.FromPos.X, (float)this.ToPos.X, valueOrDefault, (data != null) ? data.LocationCurveX : null);
			this.LocationYTween.PlayTween((float)this.FromPos.Z, (float)this.ToPos.Z, valueOrDefault, (data != null) ? data.LocationCurveY : null);
		}

		// Token: 0x04020194 RID: 131476
		private UUIItem CardItem;

		// Token: 0x04020195 RID: 131477
		protected Vector FromPos = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04020196 RID: 131478
		protected Vector ToPos = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04020197 RID: 131479
		protected Vector CardWorldPos = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04020198 RID: 131480
		protected LguiFloatTween LocationXTween;

		// Token: 0x04020199 RID: 131481
		protected LguiFloatTween LocationYTween;

		// Token: 0x0402019A RID: 131482
		private Action CompleteCallback;
	}
}

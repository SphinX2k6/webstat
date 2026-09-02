using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055A7 RID: 21927
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaBattleLoadingItem : GridProxyAbstract<IPhantomArenaBattleLoadingInfo>
	{
		// Token: 0x06037CED RID: 228589 RVA: 0x00E23A73 File Offset: 0x00E21C73
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x06037CEE RID: 228590 RVA: 0x00E23AAC File Offset: 0x00E21CAC
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBattleLoadingItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBattleLoadingItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037CEF RID: 228591 RVA: 0x00E23AF0 File Offset: 0x00E21CF0
		public override void Refresh(IPhantomArenaBattleLoadingInfo data, bool isSelected, int gridIndex)
		{
			if (data.CardData != null)
			{
				this.CardItem.SetUiActive(true);
				UUISprite sprite = base.GetSprite(1);
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				this.CardItem.Refresh(data.CardData);
				return;
			}
			this.CardItem.SetUiActive(false);
			UUISprite sprite2 = base.GetSprite(1);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(true);
			}
			if (data.IsMe)
			{
				string resourceId = (data.Index < 3) ? "SP_LoadingMeFront" : "SP_LoadingMeBack";
				this.RefreshCardFaceByResource(resourceId);
				return;
			}
			string resourceId2 = (data.Index >= 3) ? "SP_LoadingPlayerFront" : "SP_LoadingPlayerBack";
			this.RefreshCardFaceByResource(resourceId2);
		}

		// Token: 0x06037CF0 RID: 228592 RVA: 0x00E23B98 File Offset: 0x00E21D98
		public void RefreshCardFaceByResource(string resourceId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (resourcePath != null)
			{
				UUISprite sprite = base.GetSprite(1);
				if (sprite != null)
				{
					this.SetSpriteByPath(resourcePath, sprite, false, null, null);
				}
			}
		}

		// Token: 0x0401FF4D RID: 130893
		private const int CARD_FRONT = 3;

		// Token: 0x0401FF4E RID: 130894
		private const int CARD_TOTAL = 6;

		// Token: 0x0401FF4F RID: 130895
		protected PhantomArenaCard CardItem;

		// Token: 0x0200B530 RID: 46384
		[NullableContext(0)]
		private class ELoadingItem
		{
			// Token: 0x0403815F RID: 229727
			public const int CardItem = 0;

			// Token: 0x04038160 RID: 229728
			public const int SpriteState = 1;
		}
	}
}

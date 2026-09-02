using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006906 RID: 26886
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class DropCatchPauseScoreItem : GridProxyAbstract<IScoreLevelItemData>
	{
		// Token: 0x06042CA0 RID: 273568 RVA: 0x01123FC4 File Offset: 0x011221C4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06042CA1 RID: 273569 RVA: 0x01124020 File Offset: 0x01122220
		protected override UniTask OnBeforeStartAsync()
		{
			DropCatchPauseScoreItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DropCatchPauseScoreItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042CA2 RID: 273570 RVA: 0x01124064 File Offset: 0x01122264
		public override void Refresh(IScoreLevelItemData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), EDropCatchTextId.TextScoreLevel.ToEnumString(), new <>z__ReadOnlySingleElementList<object>(data.Score));
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(data.IsFinish);
			}
			DropCatchStarItemView starItemView = this.StarItemView;
			if (starItemView == null)
			{
				return;
			}
			starItemView.Refresh(data.IsFinish);
		}

		// Token: 0x04025367 RID: 152423
		[Nullable(2)]
		private DropCatchStarItemView StarItemView;
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.CoreCard
{
	// Token: 0x020055CC RID: 21964
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCoreCardView : UiViewBase, IUiViewResource
	{
		// Token: 0x06037F47 RID: 229191 RVA: 0x00E2C85A File Offset: 0x00E2AA5A
		public PhantomArenaCoreCardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037F48 RID: 229192 RVA: 0x00E2C864 File Offset: 0x00E2AA64
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnCloseClick))
			};
		}

		// Token: 0x06037F49 RID: 229193 RVA: 0x00E2C8F7 File Offset: 0x00E2AAF7
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06037F4A RID: 229194 RVA: 0x00E2C900 File Offset: 0x00E2AB00
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaCoreCardView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaCoreCardView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037F4B RID: 229195 RVA: 0x00E2C943 File Offset: 0x00E2AB43
		protected override void OnStart()
		{
			this.Data = (this.OpenParam as IPhantomArenaCoreCardData);
			this.SetCard();
			this.SetCardTaskDesc();
			this.BindSequence();
		}

		// Token: 0x06037F4C RID: 229196 RVA: 0x00E2C968 File Offset: 0x00E2AB68
		protected override void OnBeforeDestroy()
		{
			IPhantomArenaCoreCardData data = this.Data;
			if (data == null)
			{
				return;
			}
			Action callback = data.Callback;
			if (callback == null)
			{
				return;
			}
			callback();
		}

		// Token: 0x06037F4D RID: 229197 RVA: 0x00E2C984 File Offset: 0x00E2AB84
		private UniTask InitCard()
		{
			PhantomArenaCoreCardView.<InitCard>d__9 <InitCard>d__;
			<InitCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCard>d__.<>4__this = this;
			<InitCard>d__.<>1__state = -1;
			<InitCard>d__.<>t__builder.Start<PhantomArenaCoreCardView.<InitCard>d__9>(ref <InitCard>d__);
			return <InitCard>d__.<>t__builder.Task;
		}

		// Token: 0x06037F4E RID: 229198 RVA: 0x00E2C9C8 File Offset: 0x00E2ABC8
		private void SetCard()
		{
			int taskCardConfigId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.TaskData.TaskCardConfigId;
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(taskCardConfigId);
			this.CardItem.Refresh(taskCardConfigId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phantomBattleCardConfig.Name, Array.Empty<object>());
		}

		// Token: 0x06037F4F RID: 229199 RVA: 0x00E2CA20 File Offset: 0x00E2AC20
		private void SetCardTaskDesc()
		{
			bool isAllFinish = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.TaskData.IsAllFinish;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(!isAllFinish);
			}
			if (isAllFinish)
			{
				return;
			}
			int taskCardConfigId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.TaskData.TaskCardConfigId;
			PhantomBattleFourCTask phantomArenaFourTask = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaFourTask(taskCardConfigId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), phantomArenaFourTask.CoreDesc, Array.Empty<object>());
		}

		// Token: 0x06037F50 RID: 229200 RVA: 0x00E2CA9A File Offset: 0x00E2AC9A
		private void BindSequence()
		{
			if (ModelBase<PhantomArenaBattleModel>.Instance.OwnData.TaskData.IsAllFinish)
			{
				this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.PlayUpdateSequence));
			}
		}

		// Token: 0x06037F51 RID: 229201 RVA: 0x00E2CACE File Offset: 0x00E2ACCE
		private void PlayUpdateSequence(string sequenceName, string eventName)
		{
			if (sequenceName != "Start")
			{
				return;
			}
			if (eventName == "Update")
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence == null)
				{
					return;
				}
				uiViewSequence.PlaySequencePurely("Update", false, false);
			}
		}

		// Token: 0x06037F52 RID: 229202 RVA: 0x00E2CB02 File Offset: 0x00E2AD02
		public string GetExtraResourceId([Nullable(2)] object param = null)
		{
			if (!ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				return "UiView_CoreCardNew";
			}
			return "UiView_CoreCard";
		}

		// Token: 0x04020002 RID: 131074
		protected CommonCardItem CardItem;

		// Token: 0x04020003 RID: 131075
		private IPhantomArenaCoreCardData Data;

		// Token: 0x0200B5BD RID: 46525
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040383C7 RID: 230343
			public const int CardItem = 0;

			// Token: 0x040383C8 RID: 230344
			public const int ProgressText = 1;

			// Token: 0x040383C9 RID: 230345
			public const int NameText = 2;

			// Token: 0x040383CA RID: 230346
			public const int CloseBtn = 3;
		}
	}
}

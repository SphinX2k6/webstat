using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.BlackScreen
{
	// Token: 0x02005F11 RID: 24337
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class BlackScreenController : UiControllerBase<BlackScreenController>
	{
		// Token: 0x0603D1DC RID: 250332 RVA: 0x00F86CC1 File Offset: 0x00F84EC1
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UiManagerInit, new Action(this.PreloadBlackScreen));
		}

		// Token: 0x0603D1DD RID: 250333 RVA: 0x00F86CDC File Offset: 0x00F84EDC
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UiManagerInit, new Action(this.PreloadBlackScreen));
		}

		// Token: 0x0603D1DE RID: 250334 RVA: 0x00F86CF7 File Offset: 0x00F84EF7
		private void PreloadBlackScreen()
		{
			if (this.BlackScreen != null)
			{
				return;
			}
			this.BlackScreen = new BlackScreenTransitionView();
			this.BlackScreen.CreateByResourceIdAsync("UiView_BlackScreen_Prefab", Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.CG), true);
		}

		// Token: 0x0603D1DF RID: 250335 RVA: 0x00F86D30 File Offset: 0x00F84F30
		public unsafe void AddBlackScreen(string showAnimType, string tag, string colorType = "Black")
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BlackScreen;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "触发开始黑屏";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("标签", tag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("颜色", colorType);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (this.PendingDeferredTag == tag)
			{
				this.PendingDeferredTag = null;
			}
			if (this.TagSet.Count == 0)
			{
				this.BlackScreen.ShowTemp(showAnimType, colorType);
			}
			int num;
			if (this.TagSet.TryGetValue(tag, out num))
			{
				num = (this.TagSet[tag] = num + 1);
				return;
			}
			this.TagSet[tag] = 1;
		}

		// Token: 0x0603D1E0 RID: 250336 RVA: 0x00F86DF4 File Offset: 0x00F84FF4
		public void AddBlackScreenDeferred(string showAnimType, string tag)
		{
			if (this.TagSet.Count > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BlackScreen;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "触发延迟黑屏,但系统黑幕已打开,直接引用计数";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.AddBlackScreen(showAnimType, tag, "Black");
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BlackScreen;
			ELogAuthor author2 = ELogAuthor.HYF;
			string message2 = "触发延迟黑屏,等待演出黑幕关闭时打开";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("标签", tag);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.PendingDeferredTag = tag;
			this.PendingDeferredAnimType = showAnimType;
		}

		// Token: 0x0603D1E1 RID: 250337 RVA: 0x00F86E80 File Offset: 0x00F85080
		public void ConsumePendingBlackScreen(string colorType)
		{
			if (this.PendingDeferredTag == null)
			{
				return;
			}
			string pendingDeferredTag = this.PendingDeferredTag;
			this.PendingDeferredTag = null;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BlackScreen;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "演出黑幕关闭,消费延迟黑屏标记打开系统黑幕";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", pendingDeferredTag);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.AddBlackScreen(this.PendingDeferredAnimType, pendingDeferredTag, colorType);
		}

		// Token: 0x0603D1E2 RID: 250338 RVA: 0x00F86EDC File Offset: 0x00F850DC
		public UniTask AddBlackScreenAsync(string showAnimType, string tag, string colorType = "Black")
		{
			BlackScreenController.<AddBlackScreenAsync>d__10 <AddBlackScreenAsync>d__;
			<AddBlackScreenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddBlackScreenAsync>d__.<>4__this = this;
			<AddBlackScreenAsync>d__.showAnimType = showAnimType;
			<AddBlackScreenAsync>d__.tag = tag;
			<AddBlackScreenAsync>d__.colorType = colorType;
			<AddBlackScreenAsync>d__.<>1__state = -1;
			<AddBlackScreenAsync>d__.<>t__builder.Start<BlackScreenController.<AddBlackScreenAsync>d__10>(ref <AddBlackScreenAsync>d__);
			return <AddBlackScreenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D1E3 RID: 250339 RVA: 0x00F86F38 File Offset: 0x00F85138
		public void RemoveBlackScreen(string hideAnimType, string tag)
		{
			if (this.PendingDeferredTag == tag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BlackScreen;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "取消未消费的延迟黑屏标记";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.PendingDeferredTag = null;
			}
			if (this.BlackScreen == null)
			{
				return;
			}
			int num;
			if (!this.TagSet.TryGetValue(tag, out num) || num == 0)
			{
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BlackScreen;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "触发结束黑屏";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("标签", tag);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			if (num == 1)
			{
				this.TagSet.Remove(tag);
			}
			else
			{
				num = (this.TagSet[tag] = num - 1);
			}
			if (this.TagSet.Count == 0)
			{
				this.BlackScreen.HideTemp(hideAnimType);
			}
		}

		// Token: 0x0603D1E4 RID: 250340 RVA: 0x00F87008 File Offset: 0x00F85208
		public bool IsBlackScreenActive()
		{
			BlackScreenTransitionView blackScreen = this.BlackScreen;
			return blackScreen != null && blackScreen.IsUiActiveInHierarchy();
		}

		// Token: 0x0603D1E5 RID: 250341 RVA: 0x00F8701B File Offset: 0x00F8521B
		protected override bool OnClear()
		{
			this.PendingDeferredTag = null;
			if (this.BlackScreen != null)
			{
				this.BlackScreen.Destroy(null);
				this.BlackScreen = null;
			}
			return true;
		}

		// Token: 0x04022463 RID: 140387
		[Nullable(2)]
		private BlackScreenTransitionView BlackScreen;

		// Token: 0x04022464 RID: 140388
		private readonly Dictionary<string, int> TagSet = new Dictionary<string, int>();

		// Token: 0x04022465 RID: 140389
		[Nullable(2)]
		private string PendingDeferredTag;

		// Token: 0x04022466 RID: 140390
		private string PendingDeferredAnimType = "None";
	}
}

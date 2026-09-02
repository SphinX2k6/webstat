using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.Splash
{
	// Token: 0x020044F8 RID: 17656
	[NullableContext(2)]
	[Nullable(0)]
	public class SplashUiView : LaunchComponentsAction
	{
		// Token: 0x0602E895 RID: 190613 RVA: 0x00B06B60 File Offset: 0x00B04D60
		[NullableContext(1)]
		public UniTask InitAsync(UObject worldContext)
		{
			SplashUiView.<InitAsync>d__14 <InitAsync>d__;
			<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.worldContext = worldContext;
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<SplashUiView.<InitAsync>d__14>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E896 RID: 190614 RVA: 0x00B06BAC File Offset: 0x00B04DAC
		protected UniTask LoadResourceAsync()
		{
			SplashUiView.<LoadResourceAsync>d__15 <LoadResourceAsync>d__;
			<LoadResourceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadResourceAsync>d__.<>4__this = this;
			<LoadResourceAsync>d__.<>1__state = -1;
			<LoadResourceAsync>d__.<>t__builder.Start<SplashUiView.<LoadResourceAsync>d__15>(ref <LoadResourceAsync>d__);
			return <LoadResourceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E897 RID: 190615 RVA: 0x00B06BEF File Offset: 0x00B04DEF
		[NullableContext(1)]
		private void OnUiRootLoadCallback(AActor actor)
		{
			this.UiRoot = actor;
		}

		// Token: 0x0602E898 RID: 190616 RVA: 0x00B06BF8 File Offset: 0x00B04DF8
		[NullableContext(1)]
		private void OnViewLoadCallback(AActor actor)
		{
			base.SetRootActorLaunchComponentsAction(actor);
			this.UiActor = (this.RootItem.GetOwner() as AUIBaseActor);
		}

		// Token: 0x0602E899 RID: 190617 RVA: 0x00B06C17 File Offset: 0x00B04E17
		protected override void OnStart()
		{
			this.LanguageSuffixName = Singleton<LauncherLanguageLib>.Instance.PackageLanguage;
			this.DefaultLanguageSuffixName = Singleton<LauncherLanguageLib>.Instance.GetDefaultCulture(this.LanguageSuffixName);
		}

		// Token: 0x0602E89A RID: 190618 RVA: 0x00B06C3F File Offset: 0x00B04E3F
		protected override void OnBeforeDestroy()
		{
			if (this.DataTable != null)
			{
				this.DataTable = null;
			}
			this.UiActor = null;
			this.DataMap = null;
			this.LogoTexture = null;
			this.GameSplashTexture = null;
			this.LanguageSuffixName = null;
			this.DefaultLanguageSuffixName = null;
		}

		// Token: 0x0602E89B RID: 190619 RVA: 0x00B06C7A File Offset: 0x00B04E7A
		private void OnInitAndShow()
		{
			this.UpdateTexture();
			this.UpdateText();
		}

		// Token: 0x0602E89C RID: 190620 RVA: 0x00B06C88 File Offset: 0x00B04E88
		private void UpdateTexture()
		{
			base.GetTexture(3).SetTexture(this.LogoTexture);
			base.GetTexture(3).SetSizeFromTexture();
			if (this.GetIfGlobal())
			{
				base.GetTexture(3).SetUIActive(true);
			}
		}

		// Token: 0x0602E89D RID: 190621 RVA: 0x00B06CBD File Offset: 0x00B04EBD
		private bool GetIfGlobal()
		{
			return Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN";
		}

		// Token: 0x0602E89E RID: 190622 RVA: 0x00B06CD8 File Offset: 0x00B04ED8
		private void UpdateText()
		{
			bool ifGlobal = this.GetIfGlobal();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "TsSplash";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ifglobal", ifGlobal);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			string localText = this.GetLocalText(this.LanguageSuffixName, "SplashCautionTitle");
			if (localText == "" || localText == null)
			{
				localText = this.GetLocalText(this.DefaultLanguageSuffixName, "SplashCautionTitle");
			}
			base.GetText(5).SetText(localText, true);
			string localText2 = this.GetLocalText(this.LanguageSuffixName, "SplashCautionContent");
			if (localText2 == "" || localText2 == null)
			{
				localText2 = this.GetLocalText(this.DefaultLanguageSuffixName, "SplashCautionContent");
			}
			base.GetText(6).SetText(localText2, true);
			string localText3 = this.GetLocalText(this.LanguageSuffixName, "SplashLoading");
			if (localText3 == "" || localText3 == null)
			{
				localText3 = this.GetLocalText(this.DefaultLanguageSuffixName, "SplashLoading");
			}
			base.GetText(7).SetText(localText3, true);
			string text = "";
			if (!ifGlobal)
			{
				text = this.GetLocalText(this.LanguageSuffixName, "SplashHealthyGamingAdvisory");
				if (text == "" || text == null)
				{
					text = this.GetLocalText(this.DefaultLanguageSuffixName, "SplashHealthyGamingAdvisory");
				}
			}
			base.GetText(0).SetText(text, true);
			string text2 = "";
			if (!ifGlobal)
			{
				text2 = this.GetLocalText(this.LanguageSuffixName, "SplashCopyrightInformation");
				if (text2 == "" || text2 == null)
				{
					text2 = this.GetLocalText(this.DefaultLanguageSuffixName, "SplashCopyrightInformation");
				}
			}
			base.GetText(1).SetText(text2, true);
		}

		// Token: 0x0602E89F RID: 190623 RVA: 0x00B06E7C File Offset: 0x00B0507C
		public void PlayAnimationLogo(Action finishCallback = null)
		{
			if (this.GetIfGlobal())
			{
				this.PlaySequenceByName("LogoAnimation", finishCallback);
				return;
			}
			this.PlaySequenceByName("LogoAnimationMain", finishCallback);
		}

		// Token: 0x0602E8A0 RID: 190624 RVA: 0x00B06E9F File Offset: 0x00B0509F
		public void PlayWuthering(Action finishCallback = null)
		{
			this.PlaySequenceByName("WutheringWaveAnimation", finishCallback);
		}

		// Token: 0x0602E8A1 RID: 190625 RVA: 0x00B06EAD File Offset: 0x00B050AD
		public void PlayCautionAnimation(Action finishCallback = null)
		{
			this.PlaySequenceByName("CautionAnimation", finishCallback);
		}

		// Token: 0x0602E8A2 RID: 190626 RVA: 0x00B06EBB File Offset: 0x00B050BB
		public void PlayPreventAddictionAnimation(Action finishCallback = null)
		{
			this.PlaySequenceByName("PreventAddiction", finishCallback);
		}

		// Token: 0x0602E8A3 RID: 190627 RVA: 0x00B06EC9 File Offset: 0x00B050C9
		public void StopCurrentAnimation()
		{
			this.StopCurrentSequence();
		}

		// Token: 0x0602E8A4 RID: 190628 RVA: 0x00B06ED1 File Offset: 0x00B050D1
		[NullableContext(1)]
		private string GetLocalText(string culture, string textTableId)
		{
			return Singleton<LauncherConfigLib>.Instance.GetHotPatchText(textTableId) ?? "";
		}

		// Token: 0x0602E8A5 RID: 190629 RVA: 0x00B06EE8 File Offset: 0x00B050E8
		private UniTask InitTextureAsync()
		{
			SplashUiView.<InitTextureAsync>d__30 <InitTextureAsync>d__;
			<InitTextureAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTextureAsync>d__.<>4__this = this;
			<InitTextureAsync>d__.<>1__state = -1;
			<InitTextureAsync>d__.<>t__builder.Start<SplashUiView.<InitTextureAsync>d__30>(ref <InitTextureAsync>d__);
			return <InitTextureAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E8A6 RID: 190630 RVA: 0x00B06F2C File Offset: 0x00B0512C
		[NullableContext(1)]
		private void PlaySequenceByName(string name, [Nullable(2)] Action finishCallback = null)
		{
			this.StopCurrentSequence();
			USequencePlayContext sequencePlayContextOfKey = this.UiActor.GetSequencePlayContextOfKey(name);
			if (sequencePlayContextOfKey == null)
			{
				return;
			}
			sequencePlayContextOfKey.OnFinish.Bind(delegate()
			{
				this.CurrentSequenceName = null;
				Action finishCallback2 = finishCallback;
				if (finishCallback2 == null)
				{
					return;
				}
				finishCallback2();
			});
			this.CurrentSequenceName = name;
			sequencePlayContextOfKey.ExecutePlay();
		}

		// Token: 0x0602E8A7 RID: 190631 RVA: 0x00B06F88 File Offset: 0x00B05188
		private void StopCurrentSequence()
		{
			if (this.CurrentSequenceName == null)
			{
				return;
			}
			ALevelSequenceActor sequencePlayerByKey = this.UiActor.GetSequencePlayerByKey(this.CurrentSequenceName);
			if (sequencePlayerByKey != null)
			{
				AUIBaseActor uiActor = this.UiActor;
				string currentSequenceName = this.CurrentSequenceName;
				FFrameTime time = sequencePlayerByKey.SequencePlayer.GetDuration().Time;
				uiActor.SequenceJumpToSecondByKey(currentSequenceName, time);
				this.UiActor.StopSequenceByKey(this.CurrentSequenceName);
			}
			this.CurrentSequenceName = null;
		}

		// Token: 0x0602E8A8 RID: 190632 RVA: 0x00B06FF0 File Offset: 0x00B051F0
		[NullableContext(1)]
		private UniTask LoadTableAsync(string path)
		{
			SplashUiView.<LoadTableAsync>d__33 <LoadTableAsync>d__;
			<LoadTableAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadTableAsync>d__.<>4__this = this;
			<LoadTableAsync>d__.path = path;
			<LoadTableAsync>d__.<>1__state = -1;
			<LoadTableAsync>d__.<>t__builder.Start<SplashUiView.<LoadTableAsync>d__33>(ref <LoadTableAsync>d__);
			return <LoadTableAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E8A9 RID: 190633 RVA: 0x00B0703C File Offset: 0x00B0523C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<UTexture> LoadTextureAsync(string name)
		{
			SplashUiView.<LoadTextureAsync>d__34 <LoadTextureAsync>d__;
			<LoadTextureAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UTexture>.Create();
			<LoadTextureAsync>d__.<>4__this = this;
			<LoadTextureAsync>d__.name = name;
			<LoadTextureAsync>d__.<>1__state = -1;
			<LoadTextureAsync>d__.<>t__builder.Start<SplashUiView.<LoadTextureAsync>d__34>(ref <LoadTextureAsync>d__);
			return <LoadTextureAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E8AA RID: 190634 RVA: 0x00B07087 File Offset: 0x00B05287
		public override void Destroy()
		{
			base.Destroy();
			if (this.UiRoot != null)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(this.UiRoot, true);
				this.UiRoot = null;
			}
			if (this.WorldContext != null)
			{
				this.WorldContext = null;
			}
		}

		// Token: 0x0401A6FF RID: 108287
		[Nullable(1)]
		private const string ENCOMPANYNAME = "Company_en";

		// Token: 0x0401A700 RID: 108288
		private AActor UiRoot;

		// Token: 0x0401A701 RID: 108289
		private AUIBaseActor UiActor;

		// Token: 0x0401A702 RID: 108290
		private UObject WorldContext;

		// Token: 0x0401A703 RID: 108291
		private string CurrentSequenceName;

		// Token: 0x0401A704 RID: 108292
		private string LanguageSuffixName;

		// Token: 0x0401A705 RID: 108293
		private string DefaultLanguageSuffixName;

		// Token: 0x0401A706 RID: 108294
		[Nullable(1)]
		private readonly string CompanyName = "Company_";

		// Token: 0x0401A707 RID: 108295
		[Nullable(1)]
		private readonly string LogoName = "WutheringWave_";

		// Token: 0x0401A708 RID: 108296
		private UTexture LogoTexture;

		// Token: 0x0401A709 RID: 108297
		private UTexture GameSplashTexture;

		// Token: 0x0401A70A RID: 108298
		private UDataTable DataTable;

		// Token: 0x0401A70B RID: 108299
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, string> DataMap = new Dictionary<string, string>();

		// Token: 0x0200A706 RID: 42758
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04033D62 RID: 212322
			public const int NameA = 0;

			// Token: 0x04033D63 RID: 212323
			public const int NameB = 1;

			// Token: 0x04033D64 RID: 212324
			public const int LogoItem = 2;

			// Token: 0x04033D65 RID: 212325
			public const int LogoTexture = 3;

			// Token: 0x04033D66 RID: 212326
			public const int TipItem = 4;

			// Token: 0x04033D67 RID: 212327
			public const int TxtTipTitle = 5;

			// Token: 0x04033D68 RID: 212328
			public const int TxtTip = 6;

			// Token: 0x04033D69 RID: 212329
			public const int TxtLoading = 7;
		}
	}
}

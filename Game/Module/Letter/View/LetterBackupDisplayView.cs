using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Letter.View
{
	// Token: 0x02005A1F RID: 23071
	[NullableContext(1)]
	[Nullable(0)]
	public class LetterBackupDisplayView : UiViewBase
	{
		// Token: 0x0603A689 RID: 239241 RVA: 0x00ECF1B2 File Offset: 0x00ECD3B2
		public LetterBackupDisplayView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A68A RID: 239242 RVA: 0x00ECF1C8 File Offset: 0x00ECD3C8
		private static string BuildLetterTitleTid(int letterId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("WriteLetter_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(letterId);
			defaultInterpolatedStringHandler.AppendLiteral("_Title");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0603A68B RID: 239243 RVA: 0x00ECF208 File Offset: 0x00ECD408
		private static List<ITalkItem> BuildSyntheticTalkItems([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlySet<string> keys)
		{
			if (keys == null || keys.Count == 0)
			{
				return new List<ITalkItem>();
			}
			List<ITalkItem> list = new List<ITalkItem>();
			int num = 0;
			foreach (string tidTalk in keys)
			{
				list.Add(new ITalkItem
				{
					Id = num,
					Name = "",
					TidTalk = tidTalk,
					Options = new List<ITalkOption>(),
					Actions = new List<ActionInfo>()
				});
				num++;
			}
			return list;
		}

		// Token: 0x0603A68C RID: 239244 RVA: 0x00ECF2A4 File Offset: 0x00ECD4A4
		[NullableContext(2)]
		private static ILetterBackupDisplayViewOpenParam NormalizeOpenParam(object raw)
		{
			if (raw is int)
			{
				int letterId = (int)raw;
				return new LetterBackupDisplayViewOpenParam
				{
					LetterId = letterId
				};
			}
			ILetterBackupDisplayViewOpenParam letterBackupDisplayViewOpenParam = raw as ILetterBackupDisplayViewOpenParam;
			if (letterBackupDisplayViewOpenParam != null)
			{
				return new LetterBackupDisplayViewOpenParam
				{
					LetterId = letterBackupDisplayViewOpenParam.LetterId,
					Items = letterBackupDisplayViewOpenParam.Items,
					LetterStyle = letterBackupDisplayViewOpenParam.LetterStyle
				};
			}
			return null;
		}

		// Token: 0x0603A68D RID: 239245 RVA: 0x00ECF304 File Offset: 0x00ECD504
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603A68E RID: 239246 RVA: 0x00ECF390 File Offset: 0x00ECD590
		protected override UniTask OnBeforeStartAsync()
		{
			LetterBackupDisplayView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LetterBackupDisplayView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A68F RID: 239247 RVA: 0x00ECF3D3 File Offset: 0x00ECD5D3
		private void OnClickClose()
		{
			this.CloseWithBlackScreen().Forget();
		}

		// Token: 0x0603A690 RID: 239248 RVA: 0x00ECF3E0 File Offset: 0x00ECD5E0
		private UniTask CloseWithBlackScreen()
		{
			LetterBackupDisplayView.<CloseWithBlackScreen>d__12 <CloseWithBlackScreen>d__;
			<CloseWithBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseWithBlackScreen>d__.<>4__this = this;
			<CloseWithBlackScreen>d__.<>1__state = -1;
			<CloseWithBlackScreen>d__.<>t__builder.Start<LetterBackupDisplayView.<CloseWithBlackScreen>d__12>(ref <CloseWithBlackScreen>d__);
			return <CloseWithBlackScreen>d__.<>t__builder.Task;
		}

		// Token: 0x0603A691 RID: 239249 RVA: 0x00ECF423 File Offset: 0x00ECD623
		protected override void OnBeforeDestroy()
		{
			this.BlackScreenSuppressor.Restore().Forget();
		}

		// Token: 0x0402114A RID: 135498
		private const string LETTER_BACKUP_TITLE_TID = "Text_LetterBackupDisplay_Title";

		// Token: 0x0402114B RID: 135499
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402114C RID: 135500
		[Nullable(2)]
		private LetterPanel InnerLetterPanel;

		// Token: 0x0402114D RID: 135501
		private readonly LetterBlackScreenSuppressor BlackScreenSuppressor = new LetterBlackScreenSuppressor();

		// Token: 0x0200BA01 RID: 47617
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04039766 RID: 235366
			public const int ItemTopBar = 0;

			// Token: 0x04039767 RID: 235367
			public const int TxtName = 1;

			// Token: 0x04039768 RID: 235368
			public const int ItemLetterPanel = 2;
		}
	}
}

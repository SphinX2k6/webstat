using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FE6 RID: 20454
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMainConclusionInfo : GridProxyAbstract<int>
	{
		// Token: 0x06034BC9 RID: 216009 RVA: 0x00D3AF24 File Offset: 0x00D39124
		public SheriffMainConclusionInfo(SheriffMainProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x06034BCA RID: 216010 RVA: 0x00D3AF34 File Offset: 0x00D39134
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034BCB RID: 216011 RVA: 0x00D3AFDF File Offset: 0x00D391DF
		protected override void OnStart()
		{
			this.ClueLayout = new GenericLayout<SheriffConclusionClueInfo, int>(base.GetHorizontalLayout(2), new Func<SheriffConclusionClueInfo>(this.CreateClueInfoItem), null, false, true);
		}

		// Token: 0x06034BCC RID: 216012 RVA: 0x00D3B004 File Offset: 0x00D39204
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			SheriffQuestionCsv value = ConfigBase<SheriffConfig>.Instance.GetQuestionById(data).Value;
			string conclusionKey = this.Proxy.GetConclusionKey(data);
			PublicUtil instance = Singleton<PublicUtil>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ReasoningQuestion_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value.Id);
			defaultInterpolatedStringHandler.AppendLiteral("_QuestionDesc");
			string configTextByKey = instance.GetConfigTextByKey(defaultInterpolatedStringHandler.ToStringAndClear());
			int num = this.Proxy.GetQuestionList().IndexOf(data);
			LguiUtil instance2 = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(0);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Inference_Desc_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(27 + num);
			instance2.SetLocalTextNew(text, defaultInterpolatedStringHandler.ToStringAndClear(), new <>z__ReadOnlySingleElementList<object>(configTextByKey));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), conclusionKey, Array.Empty<object>());
			List<int> clueRecords = this.Proxy.GetClueRecords(num);
			this.ClueLayout.RefreshByData(clueRecords, null, true);
		}

		// Token: 0x06034BCD RID: 216013 RVA: 0x00D3B0FA File Offset: 0x00D392FA
		private SheriffConclusionClueInfo CreateClueInfoItem()
		{
			return new SheriffConclusionClueInfo();
		}

		// Token: 0x0401E637 RID: 124471
		protected SheriffMainProxy Proxy;

		// Token: 0x0401E638 RID: 124472
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SheriffConclusionClueInfo, int> ClueLayout;

		// Token: 0x0200AFC1 RID: 44993
		[NullableContext(0)]
		private static class EDefine
		{
			// Token: 0x04036895 RID: 223381
			public const int TxtTitle = 0;

			// Token: 0x04036896 RID: 223382
			public const int TxtInfo = 1;

			// Token: 0x04036897 RID: 223383
			public const int PanelHorizontal = 2;

			// Token: 0x04036898 RID: 223384
			public const int ClueItem = 3;
		}
	}
}

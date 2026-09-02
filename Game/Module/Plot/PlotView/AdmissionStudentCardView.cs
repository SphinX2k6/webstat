using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053AC RID: 21420
	[NullableContext(1)]
	[Nullable(0)]
	public class AdmissionStudentCardView : UiViewBase
	{
		// Token: 0x06036A1A RID: 223770 RVA: 0x00DD63ED File Offset: 0x00DD45ED
		public AdmissionStudentCardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06036A1B RID: 223771 RVA: 0x00DD63F8 File Offset: 0x00DD45F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036A1C RID: 223772 RVA: 0x00DD6508 File Offset: 0x00DD4708
		protected override UniTask OnBeforeStartAsync()
		{
			AdmissionStudentCardView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AdmissionStudentCardView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401F768 RID: 128872
		private const string VAR_TEXTURE = "3_0入学拍照头像";

		// Token: 0x0401F769 RID: 128873
		private const string VAR_ADDRESS = "3_0入学联系地址";

		// Token: 0x0401F76A RID: 128874
		private const string FEMALE = "_F";

		// Token: 0x0401F76B RID: 128875
		private const string MALE = "_M";

		// Token: 0x0401F76C RID: 128876
		private const string UNKNOWN_BIRTHDAY = "StudentCard_Birthday_Unknow";

		// Token: 0x0401F76D RID: 128877
		[Nullable(2)]
		private PopupCaptionItem Caption;

		// Token: 0x0200B310 RID: 45840
		[NullableContext(0)]
		private static class EChildComponent
		{
			// Token: 0x040377A2 RID: 227234
			public const int Caption = 0;

			// Token: 0x040377A3 RID: 227235
			public const int TitleTxt = 1;

			// Token: 0x040377A4 RID: 227236
			public const int IconTexture = 2;

			// Token: 0x040377A5 RID: 227237
			public const int RoleNameTxt = 3;

			// Token: 0x040377A6 RID: 227238
			public const int AcademyTxt = 4;

			// Token: 0x040377A7 RID: 227239
			public const int BirthdayTxt = 5;

			// Token: 0x040377A8 RID: 227240
			public const int AddressTxt = 6;
		}
	}
}

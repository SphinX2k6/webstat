using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005191 RID: 20881
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeRoleAffixDetailView : UiViewBase
	{
		// Token: 0x06035B76 RID: 220022 RVA: 0x00D7F6A3 File Offset: 0x00D7D8A3
		public RoguelikeRoleAffixDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035B77 RID: 220023 RVA: 0x00D7F6AC File Offset: 0x00D7D8AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035B78 RID: 220024 RVA: 0x00D7F799 File Offset: 0x00D7D999
		private void OnSelectAffix(int index)
		{
			GenericLayout<RoguelikeRoleAffixDetailToggle, int> affixLayout = this.AffixLayout;
			if (affixLayout != null)
			{
				affixLayout.SelectGridProxy(index, false);
			}
			this.RefreshDetail();
		}

		// Token: 0x06035B79 RID: 220025 RVA: 0x00D7F7B4 File Offset: 0x00D7D9B4
		private RoguelikeRoleAffixDetailToggle CreateItem()
		{
			return new RoguelikeRoleAffixDetailToggle
			{
				OnSelectCallback = new Action<int>(this.OnSelectAffix)
			};
		}

		// Token: 0x06035B7A RID: 220026 RVA: 0x00D7F7D0 File Offset: 0x00D7D9D0
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeRoleAffixDetailView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeRoleAffixDetailView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035B7B RID: 220027 RVA: 0x00D7F814 File Offset: 0x00D7DA14
		public void RefreshDetail()
		{
			int selectedGridIndex = this.AffixLayout.GetSelectedGridIndex();
			if (selectedGridIndex < 0)
			{
				return;
			}
			int id = this.ViewParam.AffixIds[selectedGridIndex];
			RogueCharacterBuff? rogueCharacterBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterBuffConfig(id);
			if (rogueCharacterBuffConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rogueCharacterBuffConfig.Value.AffixTitle, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueCharacterBuffConfig.Value.AffixDesc, rogueCharacterBuffConfig.Value.AffixDescParam());
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("RogueCharacterBuff_Type", null);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string id2 in rogueCharacterBuffConfig.Value.AffixTypeListIter())
			{
				string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(id2, null);
				stringBuilder.Append(StringUtils.Format(localTextNew, new string[]
				{
					localTextNew2
				}));
			}
			if (rogueCharacterBuffConfig.Value.AffixTypeListLength > 0)
			{
				base.GetText(6).ShowTextNew(stringBuilder.ToString());
				base.GetText(6).SetUIActive(true);
			}
			else
			{
				base.GetText(6).SetUIActive(false);
			}
			this.SetSpriteByPath(rogueCharacterBuffConfig.Value.AffixIcon, base.GetSprite(1), false, null, null);
		}

		// Token: 0x0401ED35 RID: 126261
		private IRoguelikeRoleAffixDetailViewParam ViewParam;

		// Token: 0x0401ED36 RID: 126262
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401ED37 RID: 126263
		private GenericLayout<RoguelikeRoleAffixDetailToggle, int> AffixLayout;

		// Token: 0x0200B156 RID: 45398
		[NullableContext(0)]
		private class ERoguelikeRoleAffixDetailViewDefine
		{
			// Token: 0x04036FE3 RID: 225251
			public const int CaptionItem = 0;

			// Token: 0x04036FE4 RID: 225252
			public const int SpriteIcon = 1;

			// Token: 0x04036FE5 RID: 225253
			public const int TxtName = 2;

			// Token: 0x04036FE6 RID: 225254
			public const int TxtDesc = 3;

			// Token: 0x04036FE7 RID: 225255
			public const int AffixLayout = 4;

			// Token: 0x04036FE8 RID: 225256
			public const int ItemText = 5;

			// Token: 0x04036FE9 RID: 225257
			public const int TxtClassify = 6;
		}
	}
}

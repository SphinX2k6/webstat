using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleLangCustomModel.View.Item;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleLangCustomModel.View
{
	// Token: 0x020050F7 RID: 20727
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleLangRemoveView : UiViewBase
	{
		// Token: 0x060356E7 RID: 218855 RVA: 0x00D68556 File Offset: 0x00D66756
		public RoleLangRemoveView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060356E8 RID: 218856 RVA: 0x00D68574 File Offset: 0x00D66774
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedBtnBackB));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickedBtnConfirmB));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickedBtnBackB));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060356E9 RID: 218857 RVA: 0x00D68708 File Offset: 0x00D66908
		protected override void OnStart()
		{
			IRoleLangCustomDeleteInfo roleLangCustomDeleteInfo = this.OpenParam as IRoleLangCustomDeleteInfo;
			this.RoleId = roleLangCustomDeleteInfo.RoleId;
			this.CloseCallback = roleLangCustomDeleteInfo.CloseCallback;
			this.ClickedDeleteCallback = roleLangCustomDeleteInfo.RefreshCallback;
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId);
			if (ModelBase<RoleModel>.Instance.IsMainRole(this.RoleId))
			{
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.SetText(ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "", true);
				}
			}
			else
			{
				UUIText text2 = base.GetText(1);
				if (text2 != null)
				{
					text2.ShowTextNew(roleConfig.Value.Name);
				}
			}
			this.VoiceScroll = new GenericScrollViewNew<RoleLangCustomLangDeleteItem, IRoleLangCustomLangSelectInfo>(base.GetScrollViewWithScrollbar(2), new Func<RoleLangCustomLangDeleteItem>(this.CreateVoiceActingItem), null, false, null);
			this.RefreshVoiceList();
		}

		// Token: 0x060356EA RID: 218858 RVA: 0x00D687D8 File Offset: 0x00D669D8
		protected override void OnBeforeHide()
		{
			Action closeCallback = this.CloseCallback;
			if (closeCallback == null)
			{
				return;
			}
			closeCallback();
		}

		// Token: 0x060356EB RID: 218859 RVA: 0x00D687EA File Offset: 0x00D669EA
		protected override void OnBeforeDestroy()
		{
			this.StopCurrentAudioEvent();
		}

		// Token: 0x060356EC RID: 218860 RVA: 0x00D687F4 File Offset: 0x00D669F4
		protected void RefreshVoiceList()
		{
			List<int> allLanguageTypeForAudio = Singleton<LanguageUpdateManager>.Instance.GetAllLanguageTypeForAudio();
			allLanguageTypeForAudio.Sort((int a, int b) => a - b);
			List<IRoleLangCustomLangSelectInfo> list = new List<IRoleLangCustomLangSelectInfo>();
			foreach (int langIndex in allLanguageTypeForAudio)
			{
				list.Add(new RoleLangCustomLangSelectInfo
				{
					RoleId = this.RoleId,
					LangIndex = langIndex
				});
			}
			this.StopCurrentAudioEvent();
			this.CurrentIsPlayingInfo = null;
			this.VoiceScroll.RefreshByData(list, null, false);
			this.RefreshButton();
		}

		// Token: 0x060356ED RID: 218861 RVA: 0x00D688B0 File Offset: 0x00D66AB0
		protected void RefreshButton()
		{
			base.GetButton(5).SetSelfInteractive(this.CurSelectedSet.Count > 0);
		}

		// Token: 0x060356EE RID: 218862 RVA: 0x00D688CC File Offset: 0x00D66ACC
		protected void StopCurrentAudioEvent()
		{
			if (!string.IsNullOrEmpty(this.OldAudioCode))
			{
				string roleLangStateGroup = ConfigBase<RoleConfig>.Instance.GetRoleLangStateGroup(this.OldCodeRoleId.Value);
				Singleton<AudioSystem>.Instance.SetState(roleLangStateGroup, this.OldAudioCode, false);
			}
			if (this.PlayAudioHandle != null && this.PlayAudioHandle.Value != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlayAudioHandle.Value, EAudioActionType.Stop, null);
			}
			this.PlayAudioHandle = null;
			this.OldAudioCode = null;
			this.OldCodeRoleId = null;
		}

		// Token: 0x060356EF RID: 218863 RVA: 0x00D68966 File Offset: 0x00D66B66
		private void OnClickedBtnBackB()
		{
			base.CloseMe(null);
		}

		// Token: 0x060356F0 RID: 218864 RVA: 0x00D68970 File Offset: 0x00D66B70
		private void OnClickedBtnConfirmB()
		{
			if (this.CurSelectedSet.Count == 0)
			{
				return;
			}
			List<IRoleLangCustomLangPackageInfo> list = new List<IRoleLangCustomLangPackageInfo>();
			foreach (int langIndex in this.CurSelectedSet)
			{
				list.Add(new RoleLangCustomLangPackageInfo
				{
					RoleId = this.RoleId,
					LangIndex = langIndex
				});
			}
			ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager().DeletePackage(list);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Notice_VoiceDIY_Delete_Success", Array.Empty<object>());
			this.CurSelectedSet.Clear();
			this.RefreshVoiceList();
			Action clickedDeleteCallback = this.ClickedDeleteCallback;
			if (clickedDeleteCallback == null)
			{
				return;
			}
			clickedDeleteCallback();
		}

		// Token: 0x060356F1 RID: 218865 RVA: 0x00D68A34 File Offset: 0x00D66C34
		private RoleLangCustomLangDeleteItem CreateVoiceActingItem()
		{
			return new RoleLangCustomLangDeleteItem
			{
				OnToggleStateChangedCallback = new Action<IRoleLangCustomLangSelectInfo, bool>(this.OnVoiceItemToggleStateChanged),
				OnToggleSelectedCheck = new Func<IRoleLangCustomLangSelectInfo, bool>(this.CheckVoiceSelectedCallback)
			};
		}

		// Token: 0x060356F2 RID: 218866 RVA: 0x00D68A60 File Offset: 0x00D66C60
		private void OnVoiceItemToggleStateChanged(IRoleLangCustomLangSelectInfo data, bool isSelected)
		{
			if (isSelected)
			{
				this.CurSelectedSet.Add(data.LangIndex);
			}
			else
			{
				this.CurSelectedSet.Remove(data.LangIndex);
			}
			foreach (RoleLangCustomLangDeleteItem roleLangCustomLangDeleteItem in this.VoiceScroll.GetScrollItemList())
			{
				roleLangCustomLangDeleteItem.SetSelected(this.CheckVoiceSelectedCallback(roleLangCustomLangDeleteItem.ItemData), false);
			}
			this.RefreshButton();
		}

		// Token: 0x060356F3 RID: 218867 RVA: 0x00D68AF4 File Offset: 0x00D66CF4
		private bool CheckVoiceSelectedCallback(IRoleLangCustomLangSelectInfo data)
		{
			return this.CurSelectedSet.Contains(data.LangIndex);
		}

		// Token: 0x0401EB05 RID: 125701
		protected int RoleId;

		// Token: 0x0401EB06 RID: 125702
		[Nullable(2)]
		protected Action CloseCallback;

		// Token: 0x0401EB07 RID: 125703
		[Nullable(2)]
		protected Action ClickedDeleteCallback;

		// Token: 0x0401EB08 RID: 125704
		protected GenericScrollViewNew<RoleLangCustomLangDeleteItem, IRoleLangCustomLangSelectInfo> VoiceScroll;

		// Token: 0x0401EB09 RID: 125705
		protected HashSet<int> CurSelectedSet = new HashSet<int>();

		// Token: 0x0401EB0A RID: 125706
		[Nullable(2)]
		protected IRoleLangCustomLangSelectInfo CurrentIsPlayingInfo;

		// Token: 0x0401EB0B RID: 125707
		protected int? PlayAudioHandle;

		// Token: 0x0401EB0C RID: 125708
		[Nullable(2)]
		protected string OldAudioCode;

		// Token: 0x0401EB0D RID: 125709
		protected int? OldCodeRoleId;

		// Token: 0x0401EB0E RID: 125710
		protected bool IsNormalEnd = true;

		// Token: 0x0200B094 RID: 45204
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x04036CA0 RID: 224416
			BtnBackB,
			// Token: 0x04036CA1 RID: 224417
			TxtTitle,
			// Token: 0x04036CA2 RID: 224418
			VoiceActingItemScroll,
			// Token: 0x04036CA3 RID: 224419
			VoiceActingItem,
			// Token: 0x04036CA4 RID: 224420
			TxtDesc,
			// Token: 0x04036CA5 RID: 224421
			BtnConfirmB,
			// Token: 0x04036CA6 RID: 224422
			BtnCloseAll
		}
	}
}

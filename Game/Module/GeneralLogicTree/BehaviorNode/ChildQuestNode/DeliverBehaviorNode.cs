using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemDeliver;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CE1 RID: 23777
	[NullableContext(1)]
	[Nullable(0)]
	public class DeliverBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF50 RID: 245584 RVA: 0x00F33C47 File Offset: 0x00F31E47
		public DeliverBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x1700984D RID: 38989
		// (get) Token: 0x0603BF51 RID: 245585 RVA: 0x00F33C66 File Offset: 0x00F31E66
		protected override List<int> CorrelativeEntities
		{
			get
			{
				return this.InnerCorrelativeEntities;
			}
		}

		// Token: 0x0603BF52 RID: 245586 RVA: 0x00F33C70 File Offset: 0x00F31E70
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			IHandInItemsCondition handInItemsCondition = childQuestBtNode.Condition as IHandInItemsCondition;
			if (handInItemsCondition == null)
			{
				return false;
			}
			IAddInteractOption addOption = handInItemsCondition.AddOption;
			if (addOption.Option.Type.Type != EInteractOption.Actions)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Quest, ELogAuthor.YSQ, "交付道具任务配置的交互类型错误，应配置行为序列类型的交互", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.HandInItems = handInItemsCondition.HandInItems.Items;
			this.HandInGroup = handInItemsCondition.HandInItems.GroupConfig;
			this.DescText = handInItemsCondition.HandInItems.TidDescText;
			this.TitleText = handInItemsCondition.HandInItems.TidTitleText;
			this.CanRepeat = handInItemsCondition.HandInItems.RepeatItems;
			this.InnerInteractEntityDataId = addOption.EntityId;
			this.InnerInteractOption = addOption;
			this.InnerCorrelativeEntities.Clear();
			this.InnerCorrelativeEntities.Add(addOption.EntityId);
			return true;
		}

		// Token: 0x0603BF53 RID: 245587 RVA: 0x00F33D62 File Offset: 0x00F31F62
		protected override void OnDestroy()
		{
			this.InnerInteractOption = null;
			this.HandInItems = null;
			base.OnDestroy();
		}

		// Token: 0x0603BF54 RID: 245588 RVA: 0x00F33D78 File Offset: 0x00F31F78
		protected override void AddEventsOnChildQuestStart()
		{
			base.AddEventsOnChildQuestStart();
			Singleton<EventSystem>.Instance.Add<string>(EEventName.DynamicInteractServerResponse, new Action<string>(this.OnDynamicInteract));
		}

		// Token: 0x0603BF55 RID: 245589 RVA: 0x00F33D9C File Offset: 0x00F31F9C
		protected override void RemoveEventsOnChildQuestEnd()
		{
			Singleton<EventSystem>.Instance.Remove<string>(EEventName.DynamicInteractServerResponse, new Action<string>(this.OnDynamicInteract));
			base.RemoveEventsOnChildQuestEnd();
		}

		// Token: 0x0603BF56 RID: 245590 RVA: 0x00F33DC0 File Offset: 0x00F31FC0
		private void OnDynamicInteract(string optionGuid)
		{
			if (this.InnerInteractOption == null || this.InnerInteractOption.Option.Guid != optionGuid)
			{
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.InnerInteractEntityDataId);
			if (entityByPbDataId == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Quest;
				ELogAuthor author = ELogAuthor.BB;
				string message = "交付道具的NPC不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("实体Id", this.InnerInteractEntityDataId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			PawnInfoManageComponent component = entityByPbDataId.Entity.GetComponent<PawnInfoManageComponent>();
			string npcName = ((component != null) ? component.PawnName : null) ?? "";
			if (this.HandInItems != null)
			{
				ControllerBase<ItemDeliverController>.Instance.OpenItemDeliverViewByHandInItem(this.HandInItems, npcName, this.TitleText, this.DescText, this.Context);
				return;
			}
			if (this.HandInGroup != null)
			{
				ControllerBase<ItemDeliverController>.Instance.OpenItemDeliverViewByHandInGroup(this.HandInGroup, npcName, this.TitleText, this.DescText, this.Context);
			}
		}

		// Token: 0x04021AF6 RID: 137974
		private int InnerInteractEntityDataId;

		// Token: 0x04021AF7 RID: 137975
		[Nullable(2)]
		private IAddInteractOption InnerInteractOption;

		// Token: 0x04021AF8 RID: 137976
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IHandInItem> HandInItems;

		// Token: 0x04021AF9 RID: 137977
		[Nullable(2)]
		private IHandInGroup HandInGroup;

		// Token: 0x04021AFA RID: 137978
		private string DescText = "";

		// Token: 0x04021AFB RID: 137979
		[Nullable(2)]
		private string TitleText;

		// Token: 0x04021AFC RID: 137980
		public bool CanRepeat;

		// Token: 0x04021AFD RID: 137981
		private readonly List<int> InnerCorrelativeEntities = new List<int>();
	}
}

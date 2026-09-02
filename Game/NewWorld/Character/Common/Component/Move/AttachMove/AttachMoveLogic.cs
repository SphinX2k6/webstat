using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.AttachMove;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove
{
	// Token: 0x0200493E RID: 18750
	[NullableContext(2)]
	[Nullable(0)]
	public class AttachMoveLogic
	{
		// Token: 0x0603106C RID: 200812 RVA: 0x00C2F647 File Offset: 0x00C2D847
		public virtual bool IsMoving()
		{
			return this.InState;
		}

		// Token: 0x0603106D RID: 200813 RVA: 0x00C2F64F File Offset: 0x00C2D84F
		public virtual void UpdateMove(float deltaSeconds)
		{
		}

		// Token: 0x0603106E RID: 200814 RVA: 0x00C2F651 File Offset: 0x00C2D851
		public virtual void StopMoveWithCallback(ELevelEventState result)
		{
			this.StopMove();
		}

		// Token: 0x0603106F RID: 200815 RVA: 0x00C2F65C File Offset: 0x00C2D85C
		public virtual void StopMove()
		{
			if (!this.InState)
			{
				return;
			}
			if (this.AttachHelper != null)
			{
				this.AttachHelper.DetachFromLeader();
			}
			BaseTagComponent tagComp = this.TagComp;
			AttachMoveParams @params = this.Params;
			this.RemoveTags(tagComp, (@params != null) ? @params.GameplayTagList : null);
			this.InState = false;
			this.Params = null;
			this.TagComp = null;
			this.AttachHelper = null;
			Action exitCallback = this.ExitCallback;
			this.ExitCallback = null;
			if (exitCallback == null)
			{
				return;
			}
			exitCallback();
		}

		// Token: 0x06031070 RID: 200816 RVA: 0x00C2F6D6 File Offset: 0x00C2D8D6
		public virtual void Dispose()
		{
			this.StopMove();
		}

		// Token: 0x06031071 RID: 200817 RVA: 0x00C2F6DE File Offset: 0x00C2D8DE
		[NullableContext(1)]
		public void StartHelpedAttachMoveWithData(Entity entity, CharacterActorComponent leader, BP_AttachMoveConfig_C data, [Nullable(2)] Action endCallback = null)
		{
			if (this.InState)
			{
				this.StopMove();
			}
			this.PrepareAttachMove(entity, data, endCallback);
			this.AddTags(this.TagComp, this.Params.GameplayTagList);
			this.ExecuteAttach(entity, leader);
		}

		// Token: 0x06031072 RID: 200818 RVA: 0x00C2F718 File Offset: 0x00C2D918
		[NullableContext(1)]
		protected void PrepareAttachMove(Entity entity, BP_AttachMoveConfig_C data, [Nullable(2)] Action endCallback = null)
		{
			this.Params = new AttachMoveParams(data);
			this.TagComp = entity.GetComponent<BaseTagComponent>();
			this.ExitCallback = endCallback;
			this.InState = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[AttachMove] PrepareAttachMove";
			string item = "PbDataId";
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (component != null) ? new int?(component.CreatureData.GetPbDataId()) : null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06031073 RID: 200819 RVA: 0x00C2F79C File Offset: 0x00C2D99C
		[NullableContext(1)]
		protected bool ExecuteAttach(Entity entity, CharacterActorComponent leader)
		{
			if (this.Params == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.CWZ, "[AttachMove] ExecuteAttach 未 Prepare", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.AttachHelper = new FollowerAttachHelper();
			this.AttachHelper.Init(entity);
			if (!this.AttachHelper.AttachToLeader(leader, this.Params.AttachSocket, this.Params.AttachTransform))
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.CWZ, "[AttachMove] ExecuteAttach Attach 失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.RemoveTags(this.TagComp, this.Params.GameplayTagList);
				this.AttachHelper = null;
				this.Params = null;
				this.TagComp = null;
				this.InState = false;
				return false;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[AttachMove] ExecuteAttach";
			string item = "PbDataId";
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (component != null) ? new int?(component.CreatureData.GetPbDataId()) : null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}

		// Token: 0x06031074 RID: 200820 RVA: 0x00C2F8AB File Offset: 0x00C2DAAB
		public virtual void StartAssistedWalk()
		{
		}

		// Token: 0x06031075 RID: 200821 RVA: 0x00C2F8AD File Offset: 0x00C2DAAD
		public virtual void EnterAssistedWalkIdle()
		{
		}

		// Token: 0x06031076 RID: 200822 RVA: 0x00C2F8AF File Offset: 0x00C2DAAF
		public virtual void EnterAssistedWalking()
		{
		}

		// Token: 0x06031077 RID: 200823 RVA: 0x00C2F8B1 File Offset: 0x00C2DAB1
		public virtual void LeftAssistedWalking()
		{
		}

		// Token: 0x06031078 RID: 200824 RVA: 0x00C2F8B4 File Offset: 0x00C2DAB4
		protected void AddTags(BaseTagComponent tagComp, List<int> tagList)
		{
			if (tagComp == null || this.Params == null || tagList == null || tagList.Count == 0)
			{
				return;
			}
			foreach (int tagId in tagList)
			{
				this.SetOnlyTag(tagComp, tagId, true, "AddTags");
			}
		}

		// Token: 0x06031079 RID: 200825 RVA: 0x00C2F920 File Offset: 0x00C2DB20
		protected void RemoveTags(BaseTagComponent tagComp, List<int> tagList)
		{
			if (tagComp == null || this.Params == null || tagList == null || tagList.Count == 0)
			{
				return;
			}
			foreach (int tagId in tagList)
			{
				this.SetOnlyTag(tagComp, tagId, false, "RemoveTags");
			}
		}

		// Token: 0x0603107A RID: 200826 RVA: 0x00C2F98C File Offset: 0x00C2DB8C
		[NullableContext(1)]
		protected void SetOnlyTag([Nullable(2)] BaseTagComponent tagComp, int tagId, bool add, string context)
		{
			if (tagComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[AttachMove] SetOnlyTag tagComp 无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Context", context);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (add && !tagComp.HasTag(tagId))
			{
				tagComp.AddTag(new int?(tagId));
				return;
			}
			if (!add && tagComp.HasTag(tagId))
			{
				tagComp.RemoveTag(new int?(tagId));
			}
		}

		// Token: 0x0401C394 RID: 115604
		protected bool InState;

		// Token: 0x0401C395 RID: 115605
		protected Action ExitCallback;

		// Token: 0x0401C396 RID: 115606
		protected AttachMoveParams Params;

		// Token: 0x0401C397 RID: 115607
		protected BaseTagComponent TagComp;

		// Token: 0x0401C398 RID: 115608
		protected FollowerAttachHelper AttachHelper;
	}
}

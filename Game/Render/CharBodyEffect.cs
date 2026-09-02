using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004744 RID: 18244
	[NullableContext(1)]
	[Nullable(0)]
	public class CharBodyEffect : CharRenderBase
	{
		// Token: 0x0602F562 RID: 193890 RVA: 0x00B3A18E File Offset: 0x00B3838E
		public override string GetStatName()
		{
			return "CharBodyEffect";
		}

		// Token: 0x0602F563 RID: 193891 RVA: 0x00B3A195 File Offset: 0x00B38395
		public override int GetComponentId()
		{
			return 9;
		}

		// Token: 0x0602F564 RID: 193892 RVA: 0x00B3A199 File Offset: 0x00B38399
		public override void Awake(CharRenderingComponent renderComponent)
		{
			base.Awake(renderComponent);
		}

		// Token: 0x0602F565 RID: 193893 RVA: 0x00B3A1A4 File Offset: 0x00B383A4
		private void OnEffectFinish(int handleId)
		{
			int num = this.EffectHandles.IndexOf(handleId);
			if (num < 0)
			{
				return;
			}
			this.EffectHandles.RemoveAt(num);
			Singleton<EffectSystem>.Instance.RemoveFinishCallback(handleId, new Action<int>(this.OnEffectFinish));
		}

		// Token: 0x0602F566 RID: 193894 RVA: 0x00B3A1E8 File Offset: 0x00B383E8
		public void RegisterEffect(int handleId)
		{
			if (this.EffectHandles.IndexOf(handleId) >= 0)
			{
				Singleton<EffectSystem>.Instance.UpdateBodyEffect(handleId, this.Opacity, this.Visible, this.CastShadow);
				return;
			}
			this.EffectHandles.Add(handleId);
			if (this.Opacity != 1f || !this.Visible || !this.CastShadow)
			{
				Singleton<EffectSystem>.Instance.UpdateBodyEffect(handleId, this.Opacity, this.Visible, this.CastShadow);
			}
			Singleton<EffectSystem>.Instance.AddFinishCallback(handleId, new Action<int>(this.OnEffectFinish));
		}

		// Token: 0x0602F567 RID: 193895 RVA: 0x00B3A280 File Offset: 0x00B38480
		public void UnregisterEffect(int handleId)
		{
			int num = this.EffectHandles.IndexOf(handleId);
			if (num < 0)
			{
				return;
			}
			Singleton<EffectSystem>.Instance.UpdateBodyEffect(handleId, 1f, true, true);
			this.EffectHandles.RemoveAt(num);
			Singleton<EffectSystem>.Instance.RemoveFinishCallback(handleId, new Action<int>(this.OnEffectFinish));
		}

		// Token: 0x0602F568 RID: 193896 RVA: 0x00B3A2D4 File Offset: 0x00B384D4
		public override void Start()
		{
			this.Opacity = 1f;
			for (int i = 0; i < 3; i++)
			{
				this.PendingOpacityList[i] = 1f;
			}
			TsBaseCharacter tsBaseCharacter = base.GetRenderingComponent().GetOwner() as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				if (((characterActorComponent != null) ? characterActorComponent.Entity : null) != null)
				{
					this.Entity = tsBaseCharacter.CharacterActorComponent.Entity;
					this.Handle = ModelBase<CreatureModel>.Instance.GetEntityById(this.Entity.Id);
					if (this.Handle != null)
					{
						Singleton<EventSystem>.Instance.AddWithTarget(this.Handle, EEventName.OnSetActorHidden, new Action<int, bool>(this.OnSetActorVisible));
					}
					CharRenderingComponent renderingComponent = base.GetRenderingComponent();
					bool flag;
					if (renderingComponent == null)
					{
						flag = false;
					}
					else
					{
						ECharacterRenderingType? renderType = renderingComponent.RenderType;
						ECharacterRenderingType echaracterRenderingType = ECharacterRenderingType.LocalPlayer;
						flag = (renderType.GetValueOrDefault() == echaracterRenderingType & renderType != null);
					}
					if (!flag)
					{
						CharRenderingComponent renderingComponent2 = base.GetRenderingComponent();
						bool flag2;
						if (renderingComponent2 == null)
						{
							flag2 = false;
						}
						else
						{
							ECharacterRenderingType? renderType = renderingComponent2.RenderType;
							ECharacterRenderingType echaracterRenderingType = ECharacterRenderingType.RemotePlayer;
							flag2 = (renderType.GetValueOrDefault() == echaracterRenderingType & renderType != null);
						}
						if (!flag2)
						{
							goto IL_154;
						}
					}
					Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
					Singleton<EventSystem>.Instance.Add(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
					Singleton<EventSystem>.Instance.AddWithTarget(this.Entity, EEventName.OnRoleGoDownFinish, new Action(this.OnGoDownFinish));
				}
			}
			IL_154:
			base.OnInitSuccess();
		}

		// Token: 0x0602F569 RID: 193897 RVA: 0x00B3A43C File Offset: 0x00B3863C
		public override void Update()
		{
			if (this.NeedUpdate)
			{
				this.Visible = this.PendingVisible;
				this.Opacity = 1f;
				for (int i = 0; i < 3; i++)
				{
					this.Opacity = Math.Min(this.Opacity, this.PendingOpacityList[i]);
				}
				this.CastShadow = this.PendingCastShadow;
				foreach (int id in this.EffectHandles)
				{
					Singleton<EffectSystem>.Instance.UpdateBodyEffect(id, this.Opacity, this.Visible, this.CastShadow);
				}
				this.NeedUpdate = false;
			}
		}

		// Token: 0x0602F56A RID: 193898 RVA: 0x00B3A500 File Offset: 0x00B38700
		public override void LateUpdate()
		{
		}

		// Token: 0x0602F56B RID: 193899 RVA: 0x00B3A504 File Offset: 0x00B38704
		public override void Destroy()
		{
			if (this.Handle != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.Handle, EEventName.OnSetActorHidden, new Action<int, bool>(this.OnSetActorVisible));
			}
			if (this.Entity != null)
			{
				CharRenderingComponent renderingComponent = base.GetRenderingComponent();
				bool flag;
				if (renderingComponent == null)
				{
					flag = false;
				}
				else
				{
					ECharacterRenderingType? renderType = renderingComponent.RenderType;
					ECharacterRenderingType echaracterRenderingType = ECharacterRenderingType.LocalPlayer;
					flag = (renderType.GetValueOrDefault() == echaracterRenderingType & renderType != null);
				}
				if (!flag)
				{
					CharRenderingComponent renderingComponent2 = base.GetRenderingComponent();
					bool flag2;
					if (renderingComponent2 == null)
					{
						flag2 = false;
					}
					else
					{
						ECharacterRenderingType? renderType = renderingComponent2.RenderType;
						ECharacterRenderingType echaracterRenderingType = ECharacterRenderingType.RemotePlayer;
						flag2 = (renderType.GetValueOrDefault() == echaracterRenderingType & renderType != null);
					}
					if (!flag2)
					{
						return;
					}
				}
				Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
				Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.OnRoleGoDownFinish, new Action(this.OnGoDownFinish));
			}
		}

		// Token: 0x0602F56C RID: 193900 RVA: 0x00B3A5F4 File Offset: 0x00B387F4
		public void SetOpacity(float opacity, ECharBodyEffectOpacityType type = ECharBodyEffectOpacityType.Default)
		{
			if (!this.NeedUpdate && Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.PendingOpacityList[(int)type], (double)opacity, null))
			{
				return;
			}
			this.PendingOpacityList[(int)type] = opacity;
			this.NeedUpdate = true;
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.Update();
			}, null, null);
		}

		// Token: 0x0602F56D RID: 193901 RVA: 0x00B3A653 File Offset: 0x00B38853
		public float GetOpacityConsiderVisibility()
		{
			if (!this.Visible)
			{
				return 0f;
			}
			return this.Opacity;
		}

		// Token: 0x0602F56E RID: 193902 RVA: 0x00B3A669 File Offset: 0x00B38869
		private void SetVisible(bool visible)
		{
			if (this.NeedUpdate || this.Visible != visible)
			{
				this.PendingVisible = visible;
				this.NeedUpdate = true;
				TimerSystem.Instance.Next(delegate(float _)
				{
					this.Update();
				}, null, null);
			}
		}

		// Token: 0x0602F56F RID: 193903 RVA: 0x00B3A6A3 File Offset: 0x00B388A3
		public void SetCastShadow(bool castShadow)
		{
			if (this.NeedUpdate || this.CastShadow != castShadow)
			{
				this.PendingCastShadow = castShadow;
				this.NeedUpdate = true;
				TimerSystem.Instance.Next(delegate(float _)
				{
					this.Update();
				}, null, null);
			}
		}

		// Token: 0x0602F570 RID: 193904 RVA: 0x00B3A6DD File Offset: 0x00B388DD
		protected void OnSetActorVisible(int id, bool visible)
		{
			if (this.Entity != null && id != this.Entity.Id)
			{
				return;
			}
			this.SetVisible(visible);
		}

		// Token: 0x0602F571 RID: 193905 RVA: 0x00B3A700 File Offset: 0x00B38900
		private void OnChangeTeam()
		{
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(false))
			{
				if (sceneTeamItem.IsControl())
				{
					EntityHandle entityHandle = sceneTeamItem.EntityHandle;
					if (((entityHandle != null) ? entityHandle.Entity : null) == this.Entity)
					{
						return;
					}
				}
			}
			this.SetVisible(false);
		}

		// Token: 0x0602F572 RID: 193906 RVA: 0x00B3A77C File Offset: 0x00B3897C
		private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
		{
			WorldEntity entity = newEntityHandle.Entity;
			Entity entity2 = this.Entity;
		}

		// Token: 0x0602F573 RID: 193907 RVA: 0x00B3A78C File Offset: 0x00B3898C
		private void OnGoDownFinish()
		{
			this.SetVisible(false);
		}

		// Token: 0x0401AF4C RID: 110412
		[Nullable(2)]
		protected Entity Entity;

		// Token: 0x0401AF4D RID: 110413
		[Nullable(2)]
		private EntityHandle Handle;

		// Token: 0x0401AF4E RID: 110414
		protected bool CastShadow = true;

		// Token: 0x0401AF4F RID: 110415
		protected bool Visible = true;

		// Token: 0x0401AF50 RID: 110416
		protected float Opacity = 1f;

		// Token: 0x0401AF51 RID: 110417
		protected bool PendingCastShadow = true;

		// Token: 0x0401AF52 RID: 110418
		protected bool PendingVisible = true;

		// Token: 0x0401AF53 RID: 110419
		protected float[] PendingOpacityList = new float[3];

		// Token: 0x0401AF54 RID: 110420
		protected List<int> EffectHandles = new List<int>();

		// Token: 0x0401AF55 RID: 110421
		protected bool NeedUpdate;
	}
}

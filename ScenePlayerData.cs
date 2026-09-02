using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;

// Token: 0x020034A4 RID: 13476
[NullableContext(2)]
[Nullable(0)]
public class ScenePlayerData
{
	// Token: 0x0601C6B9 RID: 116409 RVA: 0x008844B3 File Offset: 0x008826B3
	public ScenePlayerData(int playerId, int areaId)
	{
		this.PlayerId = playerId;
		this.AreaId = areaId;
		this.Location = Vector.Create();
	}

	// Token: 0x0601C6BA RID: 116410 RVA: 0x008844D4 File Offset: 0x008826D4
	public void Clear()
	{
		this.PlayerId = 0;
		this.Location = null;
		if (this.TimerNumber != null)
		{
			TimerSystem.Instance.Remove(this.TimerNumber);
		}
	}

	// Token: 0x0601C6BB RID: 116411 RVA: 0x008844FD File Offset: 0x008826FD
	public void SetTimerStart()
	{
		if (this.TimerNumber != null)
		{
			return;
		}
		this.TimerNumber = TimerSystem.Instance.Forever(delegate(float _)
		{
			this.SetLocation();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x0601C6BC RID: 116412 RVA: 0x00884531 File Offset: 0x00882731
	public int GetPlayerId()
	{
		return this.PlayerId;
	}

	// Token: 0x0601C6BD RID: 116413 RVA: 0x00884539 File Offset: 0x00882739
	public void SetRemoteSceneLoading(bool isFinish)
	{
		this.RemoteSceneLoading = isFinish;
	}

	// Token: 0x0601C6BE RID: 116414 RVA: 0x00884542 File Offset: 0x00882742
	public bool IsRemoteSceneLoading()
	{
		return this.RemoteSceneLoading;
	}

	// Token: 0x0601C6BF RID: 116415 RVA: 0x0088454C File Offset: 0x0088274C
	public void SetLocation()
	{
		SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(this.PlayerId);
		long? num;
		if (teamPlayerData == null)
		{
			num = null;
		}
		else
		{
			SceneTeamGroup currentGroup = teamPlayerData.GetCurrentGroup();
			if (currentGroup == null)
			{
				num = null;
			}
			else
			{
				SceneTeamRole currentRole = currentGroup.GetCurrentRole();
				num = ((currentRole != null) ? new long?(currentRole.CreatureDataId) : null);
			}
		}
		long? num2 = num;
		if (num2 == null)
		{
			return;
		}
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num2.Value);
		Vector vector;
		if (entity == null)
		{
			vector = null;
		}
		else
		{
			WorldEntity entity2 = entity.Entity;
			if (entity2 == null)
			{
				vector = null;
			}
			else
			{
				CharacterActorComponent component = entity2.GetComponent<CharacterActorComponent>();
				vector = ((component != null) ? component.ActorLocationProxy : null);
			}
		}
		Vector vector2 = vector;
		if (vector2 == null)
		{
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.ScenePlayerMarkItemStateChange, this.PlayerId, false);
			return;
		}
		this.Location.X = vector2.X;
		this.Location.Y = vector2.Y;
		this.Location.Z = vector2.Z;
		Singleton<EventSystem>.Instance.Emit<int, Vector>(EEventName.ScenePlayerLocationChanged, this.PlayerId, this.Location);
	}

	// Token: 0x0601C6C0 RID: 116416 RVA: 0x00884655 File Offset: 0x00882855
	public Vector GetLocation()
	{
		if (ModelBase<CreatureModel>.Instance.GetPlayerId() != this.PlayerId)
		{
			return this.Location;
		}
		if (Global.BaseCharacter == null)
		{
			return null;
		}
		CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
		if (characterActorComponent == null)
		{
			return null;
		}
		return characterActorComponent.ActorLocationProxy;
	}

	// Token: 0x0601C6C1 RID: 116417 RVA: 0x0088468E File Offset: 0x0088288E
	public int GetAreaId()
	{
		return this.AreaId;
	}

	// Token: 0x0601C6C2 RID: 116418 RVA: 0x00884696 File Offset: 0x00882896
	public void SetAreaId(int areaId)
	{
		this.AreaId = areaId;
		this.SetLocation();
	}

	// Token: 0x0400E4AC RID: 58540
	private int PlayerId;

	// Token: 0x0400E4AD RID: 58541
	private int AreaId;

	// Token: 0x0400E4AE RID: 58542
	private Vector Location;

	// Token: 0x0400E4AF RID: 58543
	private bool RemoteSceneLoading;

	// Token: 0x0400E4B0 RID: 58544
	private TimerHandle TimerNumber;

	// Token: 0x0400E4B1 RID: 58545
	private const int TIME_INTERVAL = 1000;
}

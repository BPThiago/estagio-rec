# Trabalho de Projeto de Sistemas
##### Equipe: Caio Lessa, Marcos dos Santos, Matheus S. Caldas, Thiago Borges

## Diagrama de Pacotes da Arquitetura MVC
```mermaid
graph TB
    subgraph "API REC"
        subgraph Presentation[Presentation Layer]

Controllers[Controllers<br>AlunoController<br>OrientadorController<br>EmpresaController<br>EstagioController]
        end

        subgraph Business[Business Layer]
            subgraph Models[Models]
                Entities[Entities<br>Aluno<br>Orientador<br>Empresa<br>Estagio]
                DTOs[DTOs<br>AlunoDTO<br>OrientadorDTO<br>EmpresaDTO<br>EstagioDTO]
            end
            
            subgraph Repository[Repository]
                Interfaces[Interfaces<br>IAlunoRepository<br>IOrientadorRepository<br>IEmpresaRepository<br>IEstagioRepository]
                Implementations[Implementations<br>AlunoRepository<br>OrientadorRepository<br>EmpresaRepository<br>EstagioRepository]
            end
        end

        subgraph Data[Data Layer]
            Context[Data Context<br>AppDbContext]
            InMemoryDB[In Memory Database]
        end

        Controllers -->|uses| DTOs
        Controllers -->|depends on| Interfaces
        Implementations -->|implements| Interfaces
        Implementations -->|uses| Entities
        Implementations -->|uses| Context
        Context -->|manages| Entities
        Context -->|persists| InMemoryDB

        classDef layer fill:#e6e6e6,stroke:#333,stroke-width:2px
        classDef module fill:#fff,stroke:#666
        class Presentation,Business,Data layer
        class Controllers,Models,Repository,Context,InMemoryDB module
    end

using AutoMapper;
using PolyDo.Application.DTOs;
using PolyDo.Domain.Entities;
using PolyDo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Application.Services {
    public class ParentTaskService : IParentTaskService {
        private readonly IParentTaskRepository parentTaskRepository;
        private readonly IMapper mapper;

        public ParentTaskService(IParentTaskRepository parentTaskRepository, IMapper mapper) {
            this.parentTaskRepository = parentTaskRepository;
            this.mapper = mapper;
        }

        public async Task AddTaskAsync(ParentTaskDto task) {
            var mapped = mapper.Map<ParentTask>(task);
            await parentTaskRepository.AddTaskAsync(mapped);
        }

        public async Task DeleteTaskAsync(int id) {
            await parentTaskRepository.DeleteTaskAsync(id);
        }

        public async Task<IEnumerable<ParentTaskDto>> GetAllTasksAsync() {
            var tasks = await parentTaskRepository.GetAllTasksAsync();
            var mapped = mapper.Map<IEnumerable<ParentTaskDto>>(tasks);

            return mapped;
        }

        public async Task<ParentTaskDto> GetTaskByIdAsync(int id) {
            var task = await parentTaskRepository.GetTaskByIdAsync(id);
            var mapped = mapper.Map<ParentTaskDto>(task);

            return mapped;

        }

        public async Task UpdateTaskAsync(ParentTaskDto task) {
            var mapped = mapper.Map<ParentTask>(task);
            await parentTaskRepository.UpdateTaskAsync(mapped);
        }
    }
}
